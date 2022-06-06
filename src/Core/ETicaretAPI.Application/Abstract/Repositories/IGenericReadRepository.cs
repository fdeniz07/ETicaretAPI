using System.Linq.Expressions;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Abstract.Repositories
{
    public interface IGenericReadRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetWhere(Expression<Func<T,bool>> method);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);

        Task<T> GetByIdAsyn(string id);

    }
}
