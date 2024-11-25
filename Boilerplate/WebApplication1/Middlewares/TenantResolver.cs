using BoilerplateAPI.Tenants;

namespace BoilerplateAPI.Middlewares
{
    public class TenantResolver
  {
    private readonly RequestDelegate _next;
    private readonly string _key = "tenant";
    public TenantResolver(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ICurrentTenantService currentTenantService)
    {
      context.Request.Headers.TryGetValue(_key, out var tenantFromHeader);

      if (!string.IsNullOrWhiteSpace(tenantFromHeader))
      {
        await currentTenantService.SetTenant(tenantFromHeader);
      }

      await _next(context);
    }
  }
}
