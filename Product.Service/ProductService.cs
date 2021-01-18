using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using Product.Data.Query;

namespace Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Interfaces.Models.Product>> GetActiveProducts()
        {
            return await _mediator.Send(new FindProducts());
        }
    }
}
