using F = ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstract.Repositories
{
    public interface IFileWriteRepository : IGenericWriteRepository<F::File>
    {
    }
}
