using Microsoft.AspNetCore.Mvc;
using Project.ControllerHelper;
using Project.Service;
//using Project.Shared.DTOs;
using Project.Shared;

namespace Project.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedaController : Controller
    {
        #region Variables and Properties

        private readonly ICustomerService _customerService;
        public IActionResultHelper ActionResultHelper { get; }
        #endregion

        #region Constructor

        public MonedaController(ICustomerService customerService,
            IActionResultHelper actionResultHelper)
        {
            _customerService = customerService;
            ActionResultHelper = actionResultHelper;
        }

        #endregion

        #region Methods Http

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseService<List<CustomerDTO>> responseserviceobject =
                    await _customerService.HttpGet();
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseService<CustomerDTO> responseserviceobject = await _customerService.HttpGetId(id);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        [HttpGet("{cliente}")]
        public async Task<IActionResult> Get(string cliente)
        {
            var fsd = _customerService.HttpGetByCustomer(cliente).Result.Data;
            var responseserviceobject = await _customerService.HttpGetByCustomer(cliente);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerDTO entityDTO)
        {
            ResponseService<CustomerDTO> responseserviceobject = await _customerService.HttpPost(entityDTO);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerDTO usuarioDTO)
        {
            ResponseService<CustomerDTO> responseserviceobject = await _customerService.HttpPut(usuarioDTO);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            ResponseService<int> responseserviceobject = await _customerService.HttpDelete(Id);
            return ActionResultHelper.GetActionResult(responseserviceobject);
        }


        #endregion

    }
}
