using ETicaretAPI.Application.Abstract.Repositories.Orders;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Concrete.Repositories.Orders
{
    public class OrderReadRepository : GenericReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
