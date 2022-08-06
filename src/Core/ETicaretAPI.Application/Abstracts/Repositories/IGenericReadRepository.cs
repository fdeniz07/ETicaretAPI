using System.Linq.Expressions;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Abstracts.Repositories
{
    public interface IGenericReadRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}
