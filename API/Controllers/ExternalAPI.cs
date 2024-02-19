using Microsoft.AspNetCore.Mvc;
using Primary.Application.Abstractions;
using Project.Shared;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalAPIController : ControllerBase
    {
        #region Reads Only
        private readonly IMonedaService _monedaService;
        private readonly ILogger<MonedaController> _logger;
        private readonly IExternalAPIService _externalAPIService;
        #endregion
        
        #region Constructor
        public ExternalAPIController(IMonedaService monedaService,
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

            List<MonedaCotizacionDTO> externalData = await _externalAPIService.GetCotizacionMonedasFromExternalAPI();

            //return await externalData;
            return Ok(new { ExternalData = externalData });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonedaById(int id)
        {
            // Lógica para obtener una moneda por ID 
            return (IActionResult)await _monedaService.GetMonedaByIdAsync(id);
        }

    }

}
