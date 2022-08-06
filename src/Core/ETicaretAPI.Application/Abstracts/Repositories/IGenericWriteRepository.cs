using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Abstracts.Repositories
{
    public interface IGenericWriteRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> datas);

        bool Remove(T model);

        bool RemoveRange(List<T> datas);

        Task<bool> RemoveAsync(string id);

        bool Update(T datas);

        Task<int> SaveAsync();
    }
}
