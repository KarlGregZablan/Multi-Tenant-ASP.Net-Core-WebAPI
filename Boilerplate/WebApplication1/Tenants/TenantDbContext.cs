using Microsoft.EntityFrameworkCore;

namespace BoilerplateAPI.Tenants
{
    //This is exclusive dbcontext for tenants
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
