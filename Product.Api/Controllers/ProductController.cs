using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Product.Data.Query;

namespace Product.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new FindProducts());
            return Ok(products.Select(p => MapToProduct(p)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var products = await _mediator.Send(new FindProducts());
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product == default(Service.Models.Product))
                return BadRequest();

            return Ok(MapToProduct(product));
        }

        private Models.Product MapToProduct(Service.Models.Product product)
        {
            return new Models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Categories = product.Categories.Select(c => MapToCategory(c)).ToArray()
            };
        }

        private Models.Category MapToCategory(Service.Models.Category category)
        {
            return new Models.Category
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
