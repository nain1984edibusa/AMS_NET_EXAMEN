using Microservices.Demo.Reports.Service.Application.Interfaces;
using Microservices.Demo.Reports.Service.Application.Services;
using Microservices.Demo.Reports.Service.Framework;
using Microservices.Demo.Reports.Service.Infrastructure.Clients;
using Microservices.Infrastructure.Logger;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

// 🌩️ Config Server (Spring Cloud)
builder.AddConfigServer();




// 🪵 Logging centralizado con Serilog + Logstash
builder.Host.AddSerilogLogstash();

// 🧱 Registro de servicios comunes (telemetría, Eureka, APM, etc.)
builder.Services.AddHostServices(builder.Configuration);

// 🌐 CORS para frontend Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 🧩 Servicios específicos del microservicio
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IPolicyClient, PolicyClient>();
builder.Services.AddScoped<IProductClient, ProductClient>();

// 🌍 HTTP Clients con Service Discovery
builder.Services.AddHttpClient<IPolicyClient, PolicyClient>(client =>
    client.BaseAddress = new Uri("http://policies.service:8080"));

builder.Services.AddHttpClient<IProductClient, ProductClient>(client =>
    client.BaseAddress = new Uri("http://products.service:8080"));

// 📘 Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ⚙️ Escucha en puerto 8080
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

var app = builder.Build();

// 📖 Documentación Swagger solo en desarrollo




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔐 Redirección a HTTPS fuera de producción
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// 🧭 CORS habilitado
app.UseCors("AllowAngularLocalhost");

// 🩺 Health check en /health
app.MapHealthChecks("/health");

// 🚀 Minimal API para reports
var reportsGroup = app.MapGroup("/api/reports").WithTags("Reports");

reportsGroup.MapGet("/", async ([FromServices] IReportService reportService) =>
{
    var result = await reportService.GetPolicyReportsAsync();
    return Results.Ok(result);
});


app.Run();
