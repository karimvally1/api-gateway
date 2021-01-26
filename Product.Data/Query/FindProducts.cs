using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace Product.Data.Query
{
    public class FindProducts : IRequest<IEnumerable<Service.Models.Product>>
    {
        public class Handler : IRequestHandler<FindProducts, IEnumerable<Service.Models.Product>>
        {
            private readonly IMapper _mapper;
            private readonly ProductDbContext _dbContext;

            public Handler(IMapper mapper, ProductDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<Service.Models.Product>> Handle(FindProducts request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Products.Include(p => p.Categories).ToListAsync();
                return _mapper.Map<IEnumerable<Service.Models.Product>>(result);
            }
        }
    }
}
