using BoilerplateAPI.Modules.Product.DTOs;

namespace BoilerplateAPI.Modules.Product
{
  public interface IProductService
  {
    IEnumerable<Product> GetAll();
    Product Create(CreateProductRequest data);
    bool Delete(int id);
  }
}
