using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace Review.Data.Query
{
    public class FindReview : IRequest<Service.Models.Review>
    {
        public class Query : IRequest<Service.Models.Review>
        {
            public int ReviewId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Service.Models.Review>
        {
            private readonly IMapper _mapper;
            private readonly ReviewDbContext _dbContext;

            public Handler(IMapper mapper, ReviewDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<Service.Models.Review> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Reviews.SingleOrDefaultAsync(r => r.Id == request.ReviewId);
                return _mapper.Map<Service.Models.Review>(result);
            }
        }
    }
}
