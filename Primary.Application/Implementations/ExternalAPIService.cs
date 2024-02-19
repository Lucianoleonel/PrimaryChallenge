using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Primary.Application.Abstractions;
using Primary.Domain.Validations;
using Project.Shared;
using static Primary.Domain.Helpers.EnumsHelpers;

namespace Primary.Application.Implementations
{
    public class ExternalApiOptions
    {
        public string BaseUrl { get; set; }
    }

    public class ExternalAPIService : IExternalAPIService
    {
        const string get_monedas = "get-monedas";
        const string get_cotizaciones_monedas = "get-cotizaciones-monedas";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl;
        public ExternalAPIService(IHttpClientFactory httpClientFactory, IOptions<ExternalApiOptions> options)
        {
            httpClientFactory = _httpClientFactory;
            //se obtiene la url desde el appsettings.json
            _baseUrl = options.Value.BaseUrl;
        }
         
        private List<MonedaCotizacionDTO> monedaCotizacionMock = new List<MonedaCotizacionDTO>
            {
                new MonedaCotizacionDTO(1, "Pesos", "$", "ARS", 0.90 , new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 1,"Pesos Oficial"),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 1.20, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 1,"Pesos Oficial"),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 1053.20, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[0].ToString()),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 1269.33, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[1].ToString()),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 1269.33, new DateTime(2024, 2, 16), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[1].ToString()),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 1269.33, new DateTime(2024, 2, 16), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[1].ToString()),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 1063.85, new DateTime(2024, 2, 16), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[3].ToString()),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 933.96, new DateTime(2024, 2, 16), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[4].ToString()),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 1059.20, new DateTime(2024, 2, 16), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[2].ToString()),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 930.00, new DateTime(2024, 2, 15), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[4].ToString()),
                new MonedaCotizacionDTO(2, "Dolar", "U$S", "U$S", 1056.23, new DateTime(2024, 2, 15), 1,TransaccionValidation.ListToValidateTipoCambioDescripcion[2].ToString()),
            };

        public async Task<List<MonedaCotizacionDTO>> GetCotizacionMonedasFromExternalAPI()
        {
            return (GetMockDataMonedaCotizacionDTO());
            // Utiliza la fábrica para crear una instancia de HttpClient
            var httpClient = _httpClientFactory.CreateClient();
            // Realiza una solicitud HTTP a la API externa y procesa la respuesta
            HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}{get_cotizaciones_monedas}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Deserializa la respuesta JSON en una lista de objetos DTO
                List<MonedaCotizacionDTO> data = JsonConvert.DeserializeObject<List<MonedaCotizacionDTO>>(jsonResponse);
                return data;
            }
            else
            {
                // Maneja el error de la solicitud HTTP
                throw new HttpRequestException($"Error al obtener datos de la API externa. Código de estado: {response.StatusCode}");
            }
        }

        public async Task<List<MonedaCotizacionDTO>> GetCotizacionMonedasFromExternalAPI(MonedaCotizacionRequestDTO monedaCotizacionRequestDTO)
        {
            //Filtrado retorna Filtrado por Fecha de todas las monedas
            if (String.IsNullOrEmpty(monedaCotizacionRequestDTO.Moneda))
            { 
                return (GetMockDataMonedaCotizacionDTO(monedaCotizacionRequestDTO));
            }
            //Filtrado por Fecha y Moneda
            else if (!String.IsNullOrEmpty(monedaCotizacionRequestDTO.Moneda) && monedaCotizacionRequestDTO.Fecha != DateTime.MinValue)
            {
                ValidateIsValidMoneda(monedaCotizacionRequestDTO);

                monedaCotizacionMock = monedaCotizacionMock.Where(f => f.Fecha ==
                new DateTime(monedaCotizacionRequestDTO.Fecha.Year, monedaCotizacionRequestDTO.Fecha.Month, monedaCotizacionRequestDTO.Fecha.Day)
                        && (f.CodMoneda == 1 ? $"{Monedas.Pesos}" : $"{Monedas.Dolar}") == monedaCotizacionRequestDTO.Moneda).ToList();

                return monedaCotizacionMock;
            }
            //Filtrado por Fecha y Moneda
            else
            {
                ValidateIsValidMoneda(monedaCotizacionRequestDTO);

                return (GetMockDataMonedaCotizacionDTO(monedaCotizacionRequestDTO));
            }

            void ValidateIsValidMoneda(MonedaCotizacionRequestDTO monedaCotizacionRequestDTO)
            {
                Monedas monedas;
                if (!Enum.TryParse(monedaCotizacionRequestDTO.Moneda, out monedas))
                    throw new Exception($"El tipo de moneda solo puede ser {Monedas.Pesos} o {Monedas.Dolar}");
            }

#if false
            #region Invocacion Api Externa            
            // Utiliza la fábrica para crear una instancia de HttpClient
            var httpClient = _httpClientFactory.CreateClient();
            // Realiza una solicitud HTTP a la API externa y procesa la respuesta
            HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}{get_cotizaciones_monedas}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Deserializa la respuesta JSON en una lista de objetos DTO
                List<MonedaCotizacionDTO> data = JsonConvert.DeserializeObject<List<MonedaCotizacionDTO>>(jsonResponse);
                return data;
            }
            else
            {
                // Maneja el error de la solicitud HTTP
                throw new HttpRequestException($"Error al obtener datos de la API externa. Código de estado: {response.StatusCode}");
            }
            #endregion
            
#endif
        }
        List<MonedaCotizacionDTO> GetMockDataMonedaCotizacionDTO(MonedaCotizacionRequestDTO monedaCotizacionRequestDTO = null)
        {
            if (monedaCotizacionRequestDTO != null)
            {
                monedaCotizacionMock = monedaCotizacionMock.Where(f => f.Fecha ==
                new DateTime(monedaCotizacionRequestDTO.Fecha.Year, monedaCotizacionRequestDTO.Fecha.Month, monedaCotizacionRequestDTO.Fecha.Day) 
                        || (f.CodMoneda == 1 ? $"{Monedas.Pesos}" : $"{Monedas.Dolar}") == monedaCotizacionRequestDTO.Moneda).ToList();
            }
            return monedaCotizacionMock;
        }

        List<MonedaDTO> GetMockDataMonedaDTO()
        {
            List<MonedaDTO> monedaCotizacionDTOs = new List<MonedaDTO>();
            for (int i = 0; i < 100; i++)
                monedaCotizacionDTOs.Add(new MonedaDTO($"Simbol_{i}", $"Iso_{i}", i, $"Desc_{i}"));

            return monedaCotizacionDTOs;
        }

        public async Task<List<MonedaDTO>> GetMonedasFromExternalAPI()
        {
            return GetMockDataMonedaDTO();
            // Utiliza la fábrica para crear una instancia de HttpClient
            var httpClient = _httpClientFactory.CreateClient();
            // Realiza una solicitud HTTP a la API externa y procesa la respuesta
            HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}{get_monedas}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Deserializa la respuesta JSON en una lista de objetos DTO
                List<MonedaDTO> data = JsonConvert.DeserializeObject<List<MonedaDTO>>(jsonResponse);
                return data;
            }
            else
            {
                // Maneja el error de la solicitud HTTP
                throw new HttpRequestException($"Error al obtener datos de la API externa. Código de estado: {response.StatusCode}");
            }
        }


    }


}
