using Microservices.Demo.Products.Service.Framework;
using Microservices.Infrastructure.Logger;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer(); //Disable for local development, use AddConfigServer(false) to disable Config Server
builder.Host.AddSerilogLogstash();
builder.Services.AddHostServices(builder.Configuration);

var app = builder.Build();

await app.UseHostSetupAsync();

app.Run();