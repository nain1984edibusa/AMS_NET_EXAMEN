using Microservices.Demo.Gateway.Framework;
using Microservices.Infrastructure.Logger;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer(); //Disable for local
builder.Logging.ClearProviders().SetMinimumLevel(LogLevel.Debug);
builder.Host.AddSerilogLogstash();
builder.Services.AddHostServices(builder.Configuration, builder.Environment, builder.Logging);

var app = builder.Build();

await app.UseHostSetupAsync();

await app.RunAsync();