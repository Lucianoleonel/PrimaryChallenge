using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JWTController : ControllerBase
    {
        
        private readonly ILogger<JWTController> _logger;

        public JWTController(ILogger<JWTController> logger)
        {
            _logger = logger;
        }
    }
}
