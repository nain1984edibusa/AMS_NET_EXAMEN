var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHealthChecksUI()
    .AddInMemoryStorage();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(config => config.MapHealthChecksUI(setup =>
{
    setup.UIPath = "/healthchecks-ui"; 
    setup.ApiPath = "/healthchecks-api";
}));

app.Run();