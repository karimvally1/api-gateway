using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using Common.Enums;
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
            var products = await _mediator.Send(new FindProducts());
            return products.Where(product => product.Id == (int)ProductStatusEnum.Active);
        }
    }
}
