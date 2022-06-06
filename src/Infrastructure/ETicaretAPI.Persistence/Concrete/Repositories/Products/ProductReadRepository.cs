using ETicaretAPI.Application.Abstract.Repositories.Products;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Concrete.Repositories.Products
{
    public class ProductReadRepository : GenericReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
