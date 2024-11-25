using BoilerplateAPI.Modules.Product.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoilerplateAPI.Modules.Product
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var products = _productService.GetAll();

      return Ok(products);
    }

    [HttpPost]
    public IActionResult Post(CreateProductRequest data)
    {
      var product = _productService.Create(data);

      return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _productService.Delete(id);

      return Ok(result);
    }
  }
}
