using ETicaretAPI.Application.Abstract.Repositories.Customers;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Concrete.Repositories.Customers
{
    public class CustomerWriteRepository : GenericReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
