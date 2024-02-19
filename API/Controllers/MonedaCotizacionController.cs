using Microsoft.AspNetCore.Mvc;
using Primary.Application.Abstractions;
using Primary.Domain.DTO;
using Project.Shared;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedaCotizacionController : ControllerBase
    {
        #region Reads Only
        private readonly IMonedaService _monedaService;
        private readonly IMonedaCotizacionService _cotizacionMonedaService;
        private readonly ILogger<MonedaCotizacionController> _logger;
        private readonly IExternalAPIService _externalAPIService;
        #endregion

        #region Constructor
        public MonedaCotizacionController(IMonedaService monedaService,
                                        ILogger<MonedaCotizacionController> logger,
                                         IExternalAPIService externalAPIService,
                                         IMonedaCotizacionService cotizacionMonedaService)
        {
            _monedaService = monedaService;
            _logger = logger;
            _externalAPIService = externalAPIService;
            _cotizacionMonedaService = cotizacionMonedaService;
        }
        #endregion

        [HttpGet("Moneda/{moneda}")]
        public async Task<IActionResult> GetCotizacionMonedas(string moneda)
        {
            try
            {
                if (moneda == null)
                    throw new Exception($"El paraemetro no puede ser null");

                // Obtener datos de la API externa
                var externalData = await _externalAPIService.GetCotizacionMonedasFromExternalAPI(new MonedaCotizacionRequestDTO() { Moneda = moneda });
                
                return externalData.Count == 0 ?
                    NotFound(new { Code = 400, Data = externalData , message = $"No se encontraron registros para la moneda {moneda}." })
                    : Ok(new { Code = 200, Data = externalData, message = $"Se encontraron {externalData.Count} registros." });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new
                {
                    Code = 400,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCotizacionMonedasById([FromBody] MonedaCotizacionRequestDTO monedaCotizacionRequestDTO)
        {
            try
            {
                // Obtener datos de la API externa
                var externalData = await _externalAPIService.GetCotizacionMonedasFromExternalAPI(monedaCotizacionRequestDTO);

                return externalData is null || externalData.Count == 0 ?
                    NotFound(new { Code = 404, Data = externalData, message = $"No existen cotizaciones para {monedaCotizacionRequestDTO.Moneda} fecha {monedaCotizacionRequestDTO.Fecha}" }) 
                    : Ok(new { Code = 200, Data = externalData, message = $"Se encontraron {externalData.Count} registros" });
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new
                {
                    Code = 400,
                    message = ex.Message
                });
            }
        }

        [HttpGet("MonedaByFecha/{Fecha}")]
        public async Task<IActionResult> GetAllCotizacionesMonedaByFecha(DateTime Fecha)
        {
            try
            {
                var externalData = await _externalAPIService.GetCotizacionMonedasFromExternalAPI(new MonedaCotizacionRequestDTO() { Fecha = Fecha });

                return externalData is null || externalData.Count == 0 ? 
                    NotFound(new { Code = 400, Data = externalData, message = $"No se encontraron registros para la fecha {Fecha}" })
                    : Ok(new { Code = 200, Data = externalData , message = $"Se encontraron {externalData.Count} registros" });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, message = ex.Message });
            }
        }

        [HttpGet("MonedaFecha/{Fecha}/{Moneda}")]
        public async Task<IActionResult> GetAllCotizacionesMonedaByFecha(DateTime Fecha,string Moneda)
        {
            try
            {
                var externalData = await _externalAPIService.GetCotizacionMonedasFromExternalAPI(new MonedaCotizacionRequestDTO() { Fecha = Fecha, Moneda = Moneda });

                return externalData is null || externalData.Count == 0 ?
                    NotFound(new { Code = 400, Data = externalData, message = $"No se encontraron registros para la fecha {Fecha}" })
                    : Ok(new { Code = 200, Data = externalData, message = $"Se encontraron {externalData.Count} registros" });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Code = 400, message = ex.Message });
            }
        }
    }

}
