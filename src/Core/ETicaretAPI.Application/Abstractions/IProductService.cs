using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
