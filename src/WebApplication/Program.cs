using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Hosting;
using WebApplication.Services;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();
ConfigureApp(app);
app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    ConfigureHttpClient(services, configuration);
}

static void ConfigureHttpClient(IServiceCollection services, IConfiguration configuration)
{
    var serverUrl = configuration.GetValue<string>("ServerUrl");
    services
        .AddHttpClient("WebService", c => c.BaseAddress = new Uri(serverUrl))
        .AddTypedClient<IWeatherForecastClient, WeatherForecastClient>();
}

static void ConfigureApp(Microsoft.AspNetCore.Builder.WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthorization();
    app.MapControllers();
}

public partial class Program
{
    private Program()
    {
    }
}
