using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Review.Data.Query;

namespace Review.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReview(int reviewId)
        {
            var review = await _mediator.Send(new FindReview.Query() { ReviewId = reviewId });

            if (review == default(Service.Models.Review))
                return NotFound();

            return Ok(review);
        }
    }
}
