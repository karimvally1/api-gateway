using System.Collections.Generic;
using System.Threading.Tasks;

namespace Review.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Models.Review>> GetProductReviews(int productId);
    }
}
