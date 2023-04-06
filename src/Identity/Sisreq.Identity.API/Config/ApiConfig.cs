using Microsoft.EntityFrameworkCore;

namespace Sisreq.Identity.API.Config
{
    public static class ApiConfig
    {
        public static void ConfigureApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureServices();
            services.AddEndpointsApiExplorer();
            services.AddDependencyInjection();

            services.AddIdentityServer()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseNpgsql(configuration.GetSection("ConnectionString").Value);
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseNpgsql(configuration.GetSection("ConnectionString").Value);
                })
                .AddDeveloperSigningCredential();
                // .AddAspNetIdentity<ApplicationUser>();
        }
    }
}