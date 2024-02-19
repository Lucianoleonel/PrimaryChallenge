using Microsoft.Extensions.Logging;
using Project.Application.Abstractions;
using Project.Entities.Model;
using Project.Shared;
using Project.Shared.Helpers;
using Project.Shared.Mappers;

namespace Project.Service
{

    public interface ICustomerService : IService<CustomerDTO>
    {
        Task<ResponseService<IEnumerable<CustomerDTO>>> HttpGetByCustomer(string nombre);
    }

    public class CustomerService : ICustomerService
    {
        #region Variables and Properties

        IApplication<CustomerEntity> _CustomerApplication;
        ICustomerApplication _CustomerApp;
        
        public ILogger Logger { get; }
        #endregion

        #region Constructor

        public CustomerService(IApplication<CustomerEntity> customerApplication,
                                        ICustomerApplication CustomerApp)

        {
            _CustomerApplication = customerApplication;
            _CustomerApp = CustomerApp;
        }


        #endregion

        #region Implemented Methods

        public async Task<ResponseService<List<CustomerDTO>>> HttpGet()
        {
            ResponseService<List<CustomerDTO>> responseService = new ResponseService<List<CustomerDTO>>();
            try
            {
                #region Call Data
                IList<CustomerEntity> IListOpenWeather = await _CustomerApplication.GetAllAsync();
                //MAPPER 
                List<CustomerDTO> list_OpenWeather = IListOpenWeather != null ? CustomerMapper.MapListEntityToDTO(IListOpenWeather.ToList())
                                                                                        : new List<CustomerDTO>();
                #endregion

                #region Response
                responseService.Data = CustomerMapper.MapListEntityToDTO(IListOpenWeather.ToList());
                responseService.Message = $"CANTIDAD DE REGISTROS {list_OpenWeather.Count}";
                responseService.HttpResponseMessage.StatusCode = responseService.Data != null
                                                            ? System.Net.HttpStatusCode.OK
                                                            : System.Net.HttpStatusCode.NotFound;

                return responseService;
                #endregion
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        public async Task<ResponseService<CustomerDTO>> HttpGetId(int id)
        {
            ResponseService<CustomerDTO> responseService = new ResponseService<CustomerDTO>();
            if (id == 0)
            {
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;
                return responseService;
            }

            try
            {

                var dto = CustomerMapper.MapEntityToDTO(await _CustomerApplication.GetByIdAsync(id));
                responseService.Data = dto;
                responseService.Message = "";
                responseService.HttpResponseMessage.StatusCode = responseService.Data != null ?
                                                                        System.Net.HttpStatusCode.OK :
                                                                        System.Net.HttpStatusCode.NotFound;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        public async Task<ResponseService<IEnumerable<CustomerDTO>>> HttpGetByCustomer(string cliente)
        {
            ResponseService<IEnumerable<CustomerDTO>> responseService = new ResponseService<IEnumerable<CustomerDTO>>();
            try
            {

                #region Call Data

                IEnumerable<CustomerEntity> GetCustomersbyId = await _CustomerApp.GetbyCustomer(cliente);
                //MAPPER 
                List<CustomerDTO> entity = GetCustomersbyId.Select(item => CustomerMapper.MapEntityToDTO(item)).ToList();
                
                responseService.Data = entity;
                responseService.Message = $"CANTIDAD DE REGISTROS {entity.Count} OBTENIDOS";
                responseService.HttpResponseMessage.StatusCode = responseService.Data != null
                                                            ? System.Net.HttpStatusCode.OK
                                                            : System.Net.HttpStatusCode.NotFound;
                #endregion
                return responseService;
               
            }
            catch (ArgumentException ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        public async Task<ResponseService<CustomerDTO>> HttpPost(CustomerDTO entityDTO)
        {
            ResponseService<CustomerDTO> responseService = new ResponseService<CustomerDTO>();

            try
            {

                //aqui hay que agregar validaciones del objeto , en este caso se estan haciendo en el front

                #region Mapper

                var entity = CustomerMapper.MapDTOToEntity(entityDTO);

                #endregion

                Tuple<int, CustomerEntity> entityret = await _CustomerApplication.SaveAsync(entity);

                CustomerDTO entitydto = MethodsHelpersShared.Map<CustomerEntity, CustomerDTO>(entityret.Item2);

                responseService.Data = entitydto;
                responseService.Message = $"SE INGRESARON {entityret.Item1} REGISTROS";
                responseService.HttpResponseMessage.StatusCode = entityret.Item1 > 0
                                                            ? System.Net.HttpStatusCode.OK
                                                            : System.Net.HttpStatusCode.NotFound;
                return responseService;
            }
            catch (ArgumentException ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        public async Task<ResponseService<CustomerDTO>> HttpPut(CustomerDTO entityDTO)
        {
            ResponseService<CustomerDTO> responseService = new ResponseService<CustomerDTO>();

            try
            {
                //aqui hay que agregar validaciones del objeto , en este caso se estan haciendo en el front

                #region Mapper 
                CustomerEntity entity = CustomerMapper.MapDTOToEntity(entityDTO);
                #endregion

                //ACTUALIZAR EL USUARIO  
                int entityret = await _CustomerApplication.UpdateAsync(entity);
                CustomerDTO entitydto = MethodsHelpersShared.Map<CustomerEntity, CustomerDTO>(entity);

                return new ResponseService<CustomerDTO>(entityret,
                                                        $"SE MODIFICARON {entityret} REGISTROS",
                                                        entityDTO,
                                                        entityret > 0 ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound);
            }
            catch (ArgumentException ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
            
        }

        public async Task<ResponseService<int>> HttpDelete(int id)
        {
            ResponseService<int> responseService = new ResponseService<int>();

            try
            {
                #region Validate 
                if (id == 0)
                    throw new ArgumentException("El Id debe ser mayor a 0");
                #endregion

                //ELIMINAR REGISTRO
                int entityret = await _CustomerApplication.DeleteAsync(id);

                responseService.Data = entityret;
                responseService.Message = $"SE MODIFICARON {entityret} REGISTROS";
                responseService.HttpResponseMessage.StatusCode = entityret > 0
                                            ? System.Net.HttpStatusCode.OK
                                            : System.Net.HttpStatusCode.NotFound;
                return responseService;
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return responseService;
            }
        }

        #endregion
    }

}