using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetActiveProducts();
            return Ok(products.Select(p => MapToProduct(p)));
        }

        private Models.Product MapToProduct(Interfaces.Models.Product product)
        {
            return new Models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Categories = product.Categories.Select(c => MapToCategory(c)).ToArray()
            };
        }

        private Models.Category MapToCategory(Interfaces.Models.Category category)
        {
            return new Models.Category
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
