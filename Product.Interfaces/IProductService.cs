using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product
{
    public interface IProductService
    {
        Task<IEnumerable<Interfaces.Models.Product>> GetActiveProducts();
    }
}
