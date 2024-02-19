using Microsoft.AspNetCore.Mvc;
using Primary.Application.Abstractions;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedaController : ControllerBase
    {
        #region Reads Only
        private readonly IMonedaService _monedaService;
        private readonly ILogger<MonedaController> _logger;
        private readonly IExternalAPIService _externalAPIService;
        #endregion

        #region Constructor
        public MonedaController(IMonedaService monedaService,
                                        ILogger<MonedaController> logger,
                                         IExternalAPIService externalAPIService)
        {
            _monedaService = monedaService;
            _logger = logger;
            _externalAPIService = externalAPIService;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAllMonedas()
        {
            try
            {
#if false
                // Obtener datos de la API externa
                var externalData = await _externalAPIService.GetCotizacionMonedasFromExternalAPI();
                return Ok(new { Code = 200, Data = externalData });
#else
                //Obtener todas las monedas desde la base de datos
                var monedas = await _monedaService.GetAllMonedasAsync();

                return monedas is null || monedas.Count == 0?
                   NotFound(new { Code = 404, Data = monedas, message = "No se encontraron registros" })
                  : Ok(new { Code = 200, Data = monedas , message = $"Se encontraron {monedas.Count} registros" });
#endif
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, MessageError = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonedaById(int id)
        {
            try
            {
                // Se obtiene la moneda por ID
                var Moneda = await _monedaService.GetMonedaByIdAsync(id);

                return Moneda is null || Moneda.Codigo == 0 ?
                   NotFound(new { Code = 404, Data = Moneda, message = "No se encontraron registros" })
                : Ok(new { Code = 200, Data = Moneda, message = $"Se encontro la {nameof(Moneda)} {Moneda.Descripcion} registros" });
                                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, message = ex.Message });
            }

        }

    }

}
