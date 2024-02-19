using Primary.Domain.Exceptions;
using System.Text;
using static Primary.Domain.Helpers.EnumsHelpers;
using TransaccionDTO = Project.Shared.TransaccionDTO;

namespace Primary.Domain.Validations
{
    public static class TransaccionValidation
    {
       
        /// <summary>
        /// Valida las propiedades del TransaccionDTO
        /// </summary>
        /// <param name="transaccion"></param>
        /// <exception cref="InvalidTransactionException"></exception>
        public static void IsValidModel(TransaccionDTO transaccion)
        {
            StringBuilder stringBuilder = new StringBuilder();
            //Valida el Id del Cliente
            if (transaccion.ClienteId <= 0)
                stringBuilder.AppendLine($"El Cliente {transaccion.ClienteId} es inválido");

            //Valida el Id de la Moneda 
            if (transaccion.MonedaId <= 0)
                stringBuilder.AppendLine($"La Moneda que esta proporcionando es inválida");

            //Valida el Tipo de Cambio
            if (transaccion.TipoCambio <= 0)
                stringBuilder.AppendLine($"El tipo de cambio que esta proporcionando no puede ser 0 o menor"); //Valida el Tipo de Cambio

            if (transaccion.MontoOperado <= 0)
                stringBuilder.AppendLine($"El monto a operar tiene que ser mayor a 0");

            //Valida el Tipo de Operacion no sea nulo o vacio
            if (string.IsNullOrEmpty(transaccion.TipoOperacion))
                stringBuilder.AppendLine($"El tipo de Operación no puede ser nulo o vacio");

            //Valida que la fecha sea del dia de la fecha 
            if (transaccion.Fecha.Date != DateTime.Today)
                stringBuilder.AppendLine($"La fecha proporcionada debe pertenecer al dia de hoy {DateTime.Today.ToShortDateString()}");

            //Valida el Tipo de Operacion sea solo compra o venta
            TipoTransaccion tipoTransaccion;
            if (!Enum.TryParse(transaccion.TipoOperacion, out tipoTransaccion))
                stringBuilder.AppendLine($"El tipo de Transaccion solo puede ser {TipoTransaccion.Compra} o {TipoTransaccion.Venta}");

            //Valida la descripcion del Tipo de Cambio 
            if (!ValidateTipoCambioDescripcion(transaccion.TipoCambioDescripcion))
                stringBuilder.AppendLine($"El tipo de Cambio Descripcion solo pueden ser {string.Join(',',ListToValidateTipoCambioDescripcion)}");

            //Valida que la operacion de compra de dolares no supere los 200
            if (transaccion.TipoOperacion == TipoTransaccion.Compra.ToString() && transaccion.MonedaId == (int)Monedas.Dolar
                && transaccion.MontoOperado > 200)
                stringBuilder.AppendLine($"Solo se pueden comprar hasta 200 dolares");

            if (stringBuilder.Length > 0)
                throw new InvalidTransactionException(stringBuilder.ToString());

        }


        public static List<string> ListToValidateTipoCambioDescripcion = new List<string>
        {
            new string("Dolar Oficial"),
            new string("Dolar Blue"),
            new string("Dolar Soja"),
            new string("Dolar Contado con Liquidacion"),
            new string("Dolar MEP"),
        };

        public static bool ValidateTipoCambioDescripcion(string descripcion)
            => ListToValidateTipoCambioDescripcion.Any(c => c.Equals(descripcion));

        /// <summary>
        /// Funcion que Verifica si es fin de semana
        /// </summary>
        /// <param name="fecha"></param>
        /// <exception cref="InvalidTransactionException"></exception>
        public static void EsFinDeSemana(DateTime fecha)
        {
            if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
                throw new InvalidTransactionException("Los fines de semana no se puede operar");
        }
    }

}
