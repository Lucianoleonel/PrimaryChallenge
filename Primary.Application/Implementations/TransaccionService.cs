using Primary.Application.Abstractions;
using Primary.Application.Mappers;
using Primary.Domain.Entities;
using Primary.Domain.Exceptions;
using Primary.Domain.Validations;
using Primary.Infrastructure.Abstractions;
using static Primary.Domain.Helpers.EnumsHelpers;
using TransaccionDTO = Project.Shared.TransaccionDTO;

namespace Primary.Application.Implementations
{
    public class TransaccionService : ITransaccionService
    {
        #region Variables / Contructor

        private readonly ITransaccionRepository _TransaccionRepository;
        private readonly IClienteRepository _ClienteRepository;

        public TransaccionService(ITransaccionRepository TransaccionRepository,
            IClienteRepository clienteRepository)
        {
            _TransaccionRepository = TransaccionRepository;
            _ClienteRepository = clienteRepository;
        }

        #endregion

        #region Implementations ITransaccionService

        public async Task<TransaccionDTO> GetTransactionByIdAsync(int id)
        {            
            return TransaccionMapper.Map(await _TransaccionRepository.GetTransactionByIdAsync(id) ?? new Transaccion());
        }

        public async Task<List<TransaccionDTO>> GetTransactionsAsync()
        {
            //se obtienen una lista de las transacciones generadas
            List<Transaccion> listentity = await _TransaccionRepository.GetTransactionsAsync();
            //se mapean las transacciones a transaccionesDTO,el Select  en este caso se utiliza el map de los objetos para pasarlo a la lista
            List<TransaccionDTO> listDTO = listentity.Select(TransaccionMapper.Map).ToList();
            return listDTO;
        }

        public async Task<Tuple<bool, TransaccionDTO>> InsertTransactionAsync(TransaccionDTO transaccion)
        {
            #region Validations
            //se validan las propiedades de la Transaccion
            TransaccionValidation.IsValidModel(transaccion);
            
            TransaccionValidation.EsFinDeSemana(transaccion.Fecha);
            //Se valida que el cliente existe en la base de datos
            ExisteCliente(transaccion.ClienteId);

            bool validaLimiteMensualCompra = await ValidaLimiteMensualCompradeDolares(transaccion.ClienteId, transaccion.MontoOperado);
            if (validaLimiteMensualCompra)
                throw new InvalidTransactionException($"El cliente {transaccion.ClienteId} no puede realizar la operación debido a que supero el limite mensual de compra de dolar oficial");
            
            #endregion
            //metodo que va a la base de datos a ingresar la transaccion
            var result = await _TransaccionRepository.InsertTransactionAsync(TransaccionMapper.Map(transaccion));

            return Tuple.Create(result.Item1, TransaccionMapper.Map(result.Item2));
        }

        #endregion

        #region Validaciones de Informacion de la Base de Datos

        /// <summary>
        /// Obtiene las transacciones del Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TransaccionDTO>> GetTransactionByClienteAsync(int id)
        {
            ExisteCliente(id);
            IQueryable<Transaccion> transaccionesCliente = await _TransaccionRepository.GetTransactionByClienteAsync(id);
            return transaccionesCliente.Select(TransaccionMapper.Map);
        }

        /// <summary>
        /// Valida que el cliente existe en la base de datos
        /// </summary>
        /// <param name="ClienteId"></param>
        /// <exception cref="InvalidClienteException"></exception>
        private void ExisteCliente(int ClienteId) 
        {            
            bool cliente = _ClienteRepository.ExistClienteAsync(ClienteId).Result;
            if (!cliente)
                throw new InvalidClienteException($"El cliente {ClienteId} no existe");
        }

        /// <summary>
        /// Funcion que retorna true en caso de que el cliente ingresado por parametro supere el saldo
        /// mensual de compra de Dolares
        /// </summary>
        /// <param name="clienteId"></param>
        /// <param name="montoOperado"></param>
        /// <returns></returns>
        async Task<bool> ValidaLimiteMensualCompradeDolares(int clienteId, decimal montoOperado)
        {            
            // Obtener las transacciones de compra del cliente dentro del mes actual
            IQueryable<Transaccion> transaccionesCliente = await ObtenerTransaccionesClienteEnDolares(clienteId, TipoTransaccion.Compra.ToString());
            //se obtienen las transacciones del dolar oficial
            transaccionesCliente = transaccionesCliente.Where(d => d.TipoCambioDescripcion == "Dólar Oficial");
            //si no tiene transacciones realizadas en USD no es necesario seguir validando
            if (transaccionesCliente.Count() ==0)
                return false;
            // Calcular el total de compras en USD realizadas por el cliente dentro del mes actual
            decimal totalComprasUSD = ObtieneTotalMontoOperado(transaccionesCliente);

            // Verificar si el monto operado excede el límite de compra permitido
            bool excedeLimiteCompra = (totalComprasUSD + montoOperado) > 200;

            return excedeLimiteCompra;
        }

        /// <summary>
        /// Obtiene las transacciones de Compra de USD del presente mes del cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <param name="tipoTransaccion"></param>
        /// <returns></returns>
        private async Task<IQueryable<Transaccion>> ObtenerTransaccionesClienteEnDolares(int clienteId, string tipoTransaccion)
        {
            // Obtener la fecha actual y la fecha de inicio del mes actual
            DateTime fechaActual = DateTime.Now;
            DateTime fechaInicioMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);

            // Obtener todas las transacciones de compra del cliente del presente mes
            var trans = await _TransaccionRepository.GetTransactionByClienteAsync(clienteId);
            //filtra las transacciones por Tipo de Compra y USD
            return trans.Where(t => t.ClienteId == clienteId && t.MonedaId == (int)Monedas.Dolar &&
                                t.TipoOperacion == tipoTransaccion && t.Fecha >= fechaInicioMes);

        }

        /// <summary>
        /// Funcion que retorna la sumatoria de Operaciones que se brinden del listado resultante
        /// </summary>
        /// <param name="transacciones"></param>
        /// <returns></returns>
        private decimal ObtieneTotalMontoOperado(IQueryable<Transaccion> transacciones)
        {
            // Calcular el total de compras en USD realizadas por el cliente dentro del mes actual
            return transacciones.Sum(t => t.MontoOperado);
        }



        #endregion
    }


}
