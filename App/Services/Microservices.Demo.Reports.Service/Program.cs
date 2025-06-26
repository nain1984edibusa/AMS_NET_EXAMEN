using Microservices.Demo.Reports.Service.Application.Interfaces;
using Microservices.Demo.Reports.Service.Application.Services;
using Microservices.Demo.Reports.Service.Infrastructure.Clients;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// 🔍 Eureka Discovery Client
builder.Services.AddDiscoveryClient(builder.Configuration);

// 🌐 CORS para Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 🧩 Servicios de aplicación
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IPolicyClient, PolicyClient>();
builder.Services.AddScoped<IProductClient, ProductClient>();

// 🌍 HTTP Clients con Eureka (service discovery)
builder.Services.AddHttpClient<IPolicyClient, PolicyClient>(client =>
    client.BaseAddress = new Uri("http://policies.service:8080"));
builder.Services.AddHttpClient<IProductClient, ProductClient>(client =>
    client.BaseAddress = new Uri("http://products.service:8080"));

//builder.Services.AddHttpClient<IPolicyClient, PolicyClient>(client =>
//    client.BaseAddress = new Uri("http://localhost:5182")); // Cambia a host real

//builder.Services.AddHttpClient<IProductClient, ProductClient>(client =>
//    client.BaseAddress = new Uri("http://localhost:5176")); // Cambia a host real


// 📚 Swagger para documentación de endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ⚙️ Kestrel en puerto 8080
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

var app = builder.Build();

// 🔐 Configuración del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection(); // Útil en desarrollo y staging
}

// CORS y autorización (si tienes autenticación)
//app.UseCors("AllowAngularLocalhost");
//app.UseAuthorization();

// 🚀 Minimal API: endpoints agrupados para reports
var reportsGroup = app.MapGroup("/api/reports").WithTags("Reports");

reportsGroup.MapGet("/", async ([FromServices] IReportService reportService) =>
{
    var result = await reportService.GetPolicyReportsAsync();
    return Results.Ok(result);
});

// 🏁 Ejecutar la app
app.Run();