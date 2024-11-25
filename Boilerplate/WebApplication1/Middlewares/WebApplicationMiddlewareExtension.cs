namespace BoilerplateAPI.Middlewares
{
  public static class WebApplicationMiddlewareExtension
  {
    public static void UseMiddlewares(this WebApplication app)
    {
      app.UseMiddleware<TenantResolver>();
    }
  }
}
