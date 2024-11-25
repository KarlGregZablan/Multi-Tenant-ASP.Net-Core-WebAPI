
using BoilerplateAPI.Models;
using BoilerplateAPI.Modules.Product.DTOs;

namespace BoilerplateAPI.Modules.Product
{
  public class ProductService : IProductService
  {
    private ApplicationDbContext _context;
    public ProductService(ApplicationDbContext dbContext)
    {
      _context = dbContext;
    }
    public Product Create(CreateProductRequest data)
    {
      var product = new Product();
      product.Name = data.Name;
      product.Description = data.Description;

      _context.Products.Add(product);
      _context.SaveChanges();

      return product;

    }

    public bool Delete(int id)
    {
      var product = _context.Products.FirstOrDefault(p => p.Id == id);

      if (product == null)
      {
        return false;
      }
      else
      {
        _context.Products.Remove(product);
        _context.SaveChanges();

        return true;
      }
    }

    public IEnumerable<Product> GetAll()
    {
      var products = _context.Products.ToList();

      return products;
    }
  }
}
