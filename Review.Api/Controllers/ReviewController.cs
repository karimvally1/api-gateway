using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Review.Interfaces;

namespace Review.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductReviews(int productId)
        {
            var reviews = await _reviewService.GetProductReviews(productId);
            return Ok(reviews.Select(r => MapToReview(r)));
        }

        private Models.Review MapToReview(Interfaces.Models.Review review)
        {
            return new Models.Review
            {
                Title = review.Title,
                Description = review.Description,
                Rate = review.Rating.Rate
            };
        }
    }
}
