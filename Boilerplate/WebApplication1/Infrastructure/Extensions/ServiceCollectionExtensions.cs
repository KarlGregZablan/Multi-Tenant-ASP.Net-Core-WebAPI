using BoilerplateAPI.Modules.Product;
using BoilerplateAPI.Tenants;

namespace BoilerplateAPI.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
  {
    public static void InitializeDependencies(this IServiceCollection services)
    {
      AddScopedServices(services);
      AddTransientServices(services);
      AddSingletonServices(services);
    }

    /// <summary>
    /// Add singleton services here.
    /// </summary>
    private static void AddSingletonServices(IServiceCollection services)
    {
    }

    /// <summary>
    /// Add transient services here.
    /// </summary>
    private static void AddTransientServices(IServiceCollection services)
    {
      services.AddTransient<IProductService, ProductService>();

    }

    /// <summary>
    /// Add scoped services here.
    /// </summary>
    private static void AddScopedServices(IServiceCollection services)
    {
      services.AddScoped<ICurrentTenantService, CurrentTenantService>();
    }
  }
}
