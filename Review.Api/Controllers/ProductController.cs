using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using Review.Data.Query;
using Review.Data.Command;

namespace Review.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{productId}/reviews")]
        public async Task<IActionResult> GetProductReviews(int productId)
        {
            var reviews = await _mediator.Send(new FindProductReviews.Query() { ProductId = productId });
            return Ok(reviews.Select(r => _mapper.Map<Models.Review>(r)));
        }

        [HttpPost("{productId}/reviews")]
        public async Task<IActionResult> CreateProductReview(int productId, [FromBody] Models.Review request)
        {
            var review = _mapper.Map<Service.Models.Review>(request);
            await _mediator.Send(new CreateReviewCommand() { Review = review, ProductId = productId });
            return Ok();
        }

    }
}
