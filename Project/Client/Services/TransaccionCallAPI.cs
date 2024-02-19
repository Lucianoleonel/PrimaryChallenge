using Newtonsoft.Json;
using Project.Client.Helpers;

namespace Project.Client.Services
{
    public static class TransaccionCallAPI
    {        
        public static async Task<RootClass> callService(HttpClient Http,string url)
        {
            string responseService = await Http.GetStringAsync(url);
            return JsonConvert.DeserializeObject<RootClass>(responseService);
        }

        public static async Task<RootClass> callServiceDolarByDescripcion(HttpClient Http, string Url, string Moneda)
        {           
            var url = $"{Url}MonedaCotizacion/Moneda/{Moneda}";
            string responseService = await Http.GetStringAsync(url);
            return JsonConvert.DeserializeObject<RootClass>(responseService);
        }

        public static async Task<RootClass> callServiceDolarByFecha(HttpClient Http, string Url, DateTime Fecha)
        {            
            string ShortDate = FormatDate(Fecha);
            var url = $"{Url}MonedaCotizacion/MonedaByFecha/{ShortDate}";
            string responseService = await Http.GetStringAsync(url);
            return JsonConvert.DeserializeObject<RootClass>(responseService);
        }


        public static async Task<RootClass> callServiceMonedayFecha(HttpClient Http, string Url, DateTime Fecha, string Moneda)
        {            
            string ShortDate = FormatDate(Fecha);
            var url = $"{Url}MonedaCotizacion/MonedaFecha/{ShortDate}/{Moneda}";
            string responseService = await Http.GetStringAsync(url);
            return JsonConvert.DeserializeObject<RootClass>(responseService);
        }

        static string FormatDate(DateTime Fecha) => $"{Fecha.Month}-{Fecha.Day}-{Fecha.Year}";

    }
}
