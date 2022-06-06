using ETicaretAPI.Application.Abstract.Repositories.Orders;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Concrete.Repositories.Orders
{
    public class OrderWriteRepository:GenericWriteRepository<Order>,IOrderWriteRepository
    {
        public OrderWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
