namespace Sisreq.Identity.API.Config;

public class DependencyResolver : IServiceProvider
{
    private readonly IServiceProvider _services;

    public DependencyResolver(IServiceProvider services)
    {
        _services = services;
    }

    public object? GetService(Type serviceType)
    {
        return _services.GetService(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        return _services.GetServices(serviceType);
    }

    public void Dispose()
    {
        // Nothing to dispose
    }

    public IEnumerable<ApiScope> GetApiScopes()
    {
        using var dbContext = GetDbContext();

        return dbContext.ApiScopes.ToList();
    }

    public IEnumerable<Client> GetClients()
    {
        using var dbContext = GetDbContext();

        return dbContext.Clients.ToList();
    }

    private IdentityContext GetDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
        optionsBuilder.UseNpgsql("connection_string_here");

        return new IdentityContext(optionsBuilder.Options, new ConfigurationStoreOptions());
    }
}