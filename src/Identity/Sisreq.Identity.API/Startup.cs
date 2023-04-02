namespace Sisreq.Identity.API;

public class Startup
{
    public IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureServices();
        services.AddEndpointsApiExplorer();
        services.AddDependencyInjection();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.Configure(env);
        app.UseHttpsRedirection();
        app.UseAuthorization();
    }
}