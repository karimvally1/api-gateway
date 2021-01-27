using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace Review.Data.Query
{
    public class FindReviews : IRequest<IEnumerable<Service.Models.Review>>
    {
        public class Query : IRequest<IEnumerable<Service.Models.Review>>
        {
            public int ProductId { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Service.Models.Review>>
        {
            private readonly IMapper _mapper;
            private readonly ReviewDbContext _dbContext;

            public Handler(IMapper mapper, ReviewDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<Service.Models.Review>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Reviews.ToListAsync();
                return _mapper.Map<IEnumerable<Service.Models.Review>>(result);
            }
        }
    }
}
