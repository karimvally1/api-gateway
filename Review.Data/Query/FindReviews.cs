using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace Review.Data.Query
{
    public class FindReviews : IRequest<IEnumerable<Interfaces.Models.Review>>
    {
        public class Query : IRequest<IEnumerable<Interfaces.Models.Review>>
        {
            public int ProductId { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Interfaces.Models.Review>>
        {
            private readonly IMapper _mapper;
            private readonly ReviewDbContext _dbContext;

            public Handler(IMapper mapper, ReviewDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<Interfaces.Models.Review>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Reviews.Include(r => r.Rating).ToListAsync();
                return _mapper.Map<IEnumerable<Interfaces.Models.Review>>(result);
            }
        }
    }
}
