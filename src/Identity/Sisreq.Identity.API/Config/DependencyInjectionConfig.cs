using Sisreq.Identity.Infra;

namespace Sisreq.Identity.API.Config;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {

        // Resgistering Context
        services.AddDbContext<IdentityContext>();
    }
}