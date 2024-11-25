using BoilerplateAPI.Modules.Product;
using BoilerplateAPI.Tenants;
using Microsoft.EntityFrameworkCore;

namespace BoilerplateAPI.Models
{
    public class ApplicationDbContext : DbContext
  {
    private readonly ICurrentTenantService _currentTenantService;
    public string CurrentTenantId { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
      ICurrentTenantService currentTenantService)
      : base(options)
    {
      //this part here ensures the current tenant id is set every time the db is accessed
      _currentTenantService = currentTenantService;
      CurrentTenantId = _currentTenantService.TenantId;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Tenant> Tenants { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Product>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
    }

    // the current tenantid is set everytime we save changes
    public override int SaveChanges()
    {
      foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
      {
        switch (entry.State)
        {
          case EntityState.Added:
          case EntityState.Modified:
            entry.Entity.TenantId = CurrentTenantId;
            break;
        }
      }

      var result = base.SaveChanges();
      return result;
    }
  }
}
