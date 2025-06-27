using Microservices.Demo.Reports.Service.Application.Interfaces;
using Microservices.Demo.Reports.Service.Application.Service;
using Steeltoe.Discovery.Client;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// 🚀 Inyección de dependencias
builder.Services.AddScoped<IReportService, ReportService>();

// 🔍 Eureka Discovery
builder.Services.AddDiscoveryClient(builder.Configuration);

// 🧪 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🛰️ Habilitar Discovery Client
app.UseDiscoveryClient();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Rutas
app.MapGet("/", () => "Hello from reports.service");

app.MapGet("/api/health", () =>
{
    return Results.Ok(new { status = "UP", service = "reports.service" });
});

app.MapGet("/api/reports", async ([FromServices] IReportService reportService) =>
{
    var result = await reportService.GetPolicyReportsAsync();
    return Results.Ok(result);
});

app.Run();
