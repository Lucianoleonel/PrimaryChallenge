using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project.Application.Implementations;
using Project.ControllerHelper;
using Project.DataAccess.Implementations;
using Project.Repository.Implementations;
using Project.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//obtiene el local client del appsettings.json
string localClientUrl = builder.Configuration.GetSection("Client")["LocalClient"];
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = $"{Assembly.GetCallingAssembly()}",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

#region Instanciador Scrutor
Assembly AssemblyApplication = Assembly.GetAssembly(typeof(Application<>));
builder.Services.Scan(scan =>
    scan.FromAssemblies(AssemblyApplication)
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Application")))
    .AsImplementedInterfaces()
    .WithTransientLifetime());

builder.Services.Scan(scan =>
    scan.FromAssemblies(Assembly.GetAssembly(typeof(Repository<>)))
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
    .AsImplementedInterfaces()
    .WithTransientLifetime());

builder.Services.Scan(scan =>
   scan.FromAssemblies(Assembly.GetAssembly(typeof(DbContext<>)))
   .AddClasses(classes => classes.Where(type => type.Name.EndsWith("DbContext")))
   .AsImplementedInterfaces()
   .WithTransientLifetime());

#endregion

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IActionResultHelper, ActionResultHelper>();


//se obtiene el conection string y se establece el valor al apidbcontext
builder.Services.AddDbContext<ApiDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    m => m.MigrationsAssembly("Project.Server")));

WebApplication app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

//se configuran los cors para que el front nos de el permiso para mostrar los datos
app.UseCors(builder =>
{
    builder.WithOrigins(localClientUrl)
            .WithMethods("GET, PATCH, DELETE, PUT, POST, OPTIONS")
            .AllowAnyMethod()
            .AllowAnyHeader();
});


app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
