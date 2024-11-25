namespace BoilerplateAPI.Tenants
{
  public interface ICurrentTenantService
  {
    string? TenantId { get; set; }
    Task<bool> SetTenant(string tenantId);
  }
}
