using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
var app = builder.Build();
ConfigureApp(app);
app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

static void ConfigureApp(WebApplication app)
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
