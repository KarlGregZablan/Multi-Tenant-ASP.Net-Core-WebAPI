using BoilerplateAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BoilerplateAPI.Tenants
{
  public class CurrentTenantService : ICurrentTenantService
  {
    private readonly TenantDbContext _context;
    public CurrentTenantService(TenantDbContext context)
    {
      _context = context;
    }
    public string? TenantId { get; set; }

    public async Task<bool> SetTenant(string tenantId)
    {
      var tenantInfo = await _context.Tenants.FirstOrDefaultAsync(t => t.Id == tenantId);

      if (tenantInfo != null)
      {
        TenantId = tenantInfo.Id;

        return true;
      }
      else
      {
        throw new Exception("Invalid tenant");
      }
    }
  }
}
