using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Review.Data.Query;
using Review.Data.Command;

namespace Review.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
            _httpClient = new HttpClient();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductReviews(int productId)
        {
            var reviews = await _mediator.Send(new FindReviews.Query() { ProductId = productId });
            return Ok(reviews.Select(r => MapToReview(r)));
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> CreateProductReview(int productId, [FromBody] Models.Review request)
        {
            var review = new Service.Models.Review
            {
                Title = request.Title,
                Description = request.Description,
                Rating = request.Rating
            };

            await _mediator.Send(new CreateReviewCommand() { Review = review, ProductId = productId });
            return Ok();
        }

        private Models.Review MapToReview(Service.Models.Review review)
        {
            return new Models.Review
            {
                Title = review.Title,
                Description = review.Description,
                Rating = review.Rating
            };
        }
    }
}
