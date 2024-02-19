using Microsoft.AspNetCore.Mvc;
using Primary.Application.Abstractions;
using Primary.Domain;
using Primary.Domain.DTO;
using static Primary.Application.Implementations.ExternalAPIService;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        #region Reads Only
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;
        #endregion

        #region Constructor
        public ClienteController(IClienteService clienteService,
                                        ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }
        #endregion

        [HttpPut]
        public async Task<IActionResult> InsertClientAsync([FromBody] Cliente transaccion)
        {
            try
            {
                Tuple<bool, Cliente> externalData = await _clienteService.InsertClientAsync(transaccion);

                string message = externalData.Item1 ? $"El cliente {externalData?.Item2.Id} fue ingresado con éxito"
                            : "No se pudo registrar el cliente";

                return (externalData == null || externalData?.Item1 == false) ?
                     NotFound(new { Code = 404, Data = externalData.Item2, message = message })
                    : Ok(new { Code = 200, Data = externalData.Item2, message = message });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteByIdAsync(int id)
        {
            try
            {
                Cliente Cliente = await _clienteService.GetClienteByIdAsync(id);
                return (Cliente == null || Cliente?.Id == 0) ?
                     NotFound(new { Code = 404, Data = Cliente, message = $"El cliente con Id {id} no existe" })
                    : Ok(new { Code = 200, Data = Cliente, message = "Ok" });
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
                // Obtener todos los clientes de la base de datos
                var Clientes = await _clienteService.GetAllClientesAsync();

                // Devolver una respuesta HTTP standart
                if (Clientes is null || Clientes.Count == 0)
                    return NotFound(new { Code = 404, Data = Clientes, message = "No se encontraron registros" });
                else
                    return Ok(new { Code = 200, Data = Clientes, message = $"Se encontraron {Clientes.Count} registros" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, message = ex.Message });
            }

        }

    }

}
