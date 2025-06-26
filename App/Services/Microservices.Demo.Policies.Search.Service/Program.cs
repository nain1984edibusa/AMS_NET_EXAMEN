using Microservices.Demo.Policies.Search.Service.Framework;
using Microservices.Infrastructure.Logger;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();
builder.Host.AddSerilogLogstash();
builder.Services.AddHostServices(builder.Configuration);

var app = builder.Build();

await app.UseHostSetupAsync();

app.Run();