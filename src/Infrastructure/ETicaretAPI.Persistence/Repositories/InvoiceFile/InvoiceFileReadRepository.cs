using ETicaretAPI.Application.Abstracts.Repositories;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence.Repositories
{
    public class InvoiceFileReadRepository : GenericReadRepository<ETicaretAPI.Domain.Entities.InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
