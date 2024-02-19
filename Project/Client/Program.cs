using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Project.Client;
using Project.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44330/api/") });

try
{
    var configuration = new ConfigurationBuilder()
            .AddJsonFile("launchsettings.json") // Ruta al archivo launchsettings.json
            .Build();

    builder.Configuration.AddConfiguration(configuration);
    string mySetting = configuration["profiles:Project:Server:API"];
}
catch (Exception ex)
{
   //no encuentra el archivo se intentaron varias configuraciones
}
var ro = builder.Configuration.GetSection("main");
builder.Services.AddSingleton<ApiSettings>(new ApiSettings
{
    //ESTOS DATOS OBTENERLOS DESDE EL APPSETTINGS --------------------

    BackEndApiUrl = "https://localhost:7215/api/",
   
    //ESTOS DATOS OBTENERLOS DESDE EL APPSETTINGS --------------------
});

string? origins = "origins";

builder.Services.AddAuthorizationCore(async sp =>
            sp.AddPolicy(origins,
               await GetDefaultPolicyAsync()));

await builder.Build().RunAsync();

Task<AuthorizationPolicy> GetDefaultPolicyAsync()
{
    return Task.FromResult(new AuthorizationPolicy(
        Enumerable.Empty<IAuthorizationRequirement>(),
        Enumerable.Empty<string>()));
}

