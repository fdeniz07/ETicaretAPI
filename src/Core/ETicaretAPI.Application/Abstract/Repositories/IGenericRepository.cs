using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Application.Abstract.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
