using System.Threading.Tasks;
using System.Collections.Generic;
using Review.Interfaces;
using Review.Data.Query;
using MediatR;

namespace Review.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IMediator _mediator;

        public ReviewService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Interfaces.Models.Review>> GetProductReviews(int productId)
        {
            return await _mediator.Send(new FindReviews.Query() { ProductId = productId });
        }
    }
}
