using ETicaretAPI.Application.Abstract.Repositories.Products;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Concrete.Repositories.Products
{
    public class ProductWriteRepository : GenericWriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
