using Microsoft.AspNetCore.Mvc;
using Primary.Application.Abstractions;
using Project.Shared;
using TransaccionDTO = Project.Shared.TransaccionDTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        #region Reads Only
        private readonly ITransaccionService _transaccionService;
        private readonly ILogger<TransaccionController> _logger;
        #endregion

        #region Constructor
        public TransaccionController(ITransaccionService transaccionService,
                                        ILogger<TransaccionController> logger)
        {
            _transaccionService = transaccionService;
            _logger = logger;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> InsertTransactionAsync([FromBody] TransaccionDTO transaccion)
        {
            try
            {

                Tuple<bool, TransaccionDTO> externalData = await _transaccionService.InsertTransactionAsync(transaccion);

                string message = externalData.Item1 ? $"Transaccion {externalData?.Item2.Id} ingresada con éxito"
                            : "No se pudo registrar la transaccion";
                 
                return !externalData.Item1 ?
                     NotFound(new { Code = 404, Data = externalData.Item2, message = message })
                    : Ok(new { Code = 200, Data = externalData.Item2, message = message });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, Data = string.Empty, message = ex.Message});
            }

        }

        [HttpGet("transaccionesCliente/{id}")]
        public async Task<IActionResult> GetTransactionByClienteIdAsync(int id)
        {
            try
            {   
                //Obtiene las transacciones que fueron ingresadas por cliente
                IEnumerable<TransaccionDTO> transaccionesClientes = await _transaccionService.GetTransactionByClienteAsync(id);
                
                return transaccionesClientes is null || transaccionesClientes?.Count() == 0 ?
                     NotFound(new { Code = 404, Data = transaccionesClientes, message = $"El cliente {id} no tiene transacciones" })
                    : Ok(new { Code = 201, Data = transaccionesClientes, message = $"Se encontraron {transaccionesClientes.Count()} transacciones del cliente {transaccionesClientes.FirstOrDefault().ClienteId}" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionsAsync()
        {
            try
            {
                // Obtener todas las transacciones desde la abse de datos
                var Transactions = await _transaccionService.GetTransactionsAsync();

                return Transactions is null || Transactions.Count == 0 ?
                   NotFound(new { Code = 400, Data = Transactions, message = "No se encontraron registros" })
                   : Ok(new { Code = 200, Data = Transactions, message = $"Se encontraron {Transactions.Count} registros" });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, message = ex.Message });
            }

        }

    }

}
