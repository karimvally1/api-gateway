using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
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
            };
        }
    }
}
