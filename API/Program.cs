using Microsoft.EntityFrameworkCore;
using Primary.API.Helper;
using Primary.Application.Abstractions;
using Primary.Application.Implementations;
using Primary.Infrastructure;
using Primary.Infrastructure.Abstractions;
using Primary.Infrastructure.Implementations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//invocacion del metodo que configura las inyecciones por dependencia
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//se configuran los cors para que el front nos de el permiso para mostrar los datos
string localClientUrl = builder.Configuration.GetSection("Client")["Url"];
app.UseCors(builder =>
{
    builder.WithOrigins(localClientUrl)
            .WithMethods("GET, PATCH, DELETE, PUT, POST, OPTIONS")
            .AllowAnyMethod()
            .AllowAnyHeader();
});

app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Registra las implementaciones de las interfaces
    // Configura la inyección de dependencias para IHttpClientFactory
    services.AddHttpClient();
    #region Layer Application
    services.AddScoped<IMonedaService, MonedaService>();
    services.AddScoped<IMonedaCotizacionService, MonedaCotizacionService>();
    services.AddScoped<ITransaccionService, TransaccionService>();
    services.AddScoped<IExternalAPIService, ExternalAPIService>();
    services.AddScoped<IClienteService, ClienteService>();
    #endregion

    services.Configure<ExternalApiOptions>(configuration.GetSection("ExternalAPI"));

    #region Layer Infrastucture
    services.AddScoped<IMonedaRepository, MonedaRepository>();
    services.AddScoped<IMonedaCotizacionRepository, MonedaCotizacionRepository>();
    services.AddScoped<ITransaccionRepository, TransaccionRepository>();
    services.AddTransient<IClienteRepository, ClienteRepository>();


    builder.Services.AddSingleton<IActionResultHelper, ActionResultHelper>();

    //obtiene el conectionstring de appsettings
    services.AddTransient<DbContext, ApplicationDbContext>();
    var connectionString = configuration.GetConnectionString("DB");
    services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));
    #endregion


}