﻿using BoilerplateAPI.Tenants;

namespace BoilerplateAPI.Modules.Product
{
    public class Product : IMustHaveTenant
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string TenantId { get; set; }
  }
}
