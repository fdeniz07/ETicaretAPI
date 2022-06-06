using ETicaretAPI.Application.Abstract.Repositories.Customers;
using ETicaretAPI.Application.Abstract.Repositories.Orders;
using ETicaretAPI.Application.Abstract.Repositories.Products;
using ETicaretAPI.Persistence.Concrete.Repositories.Customers;
using ETicaretAPI.Persistence.Concrete.Repositories.Orders;
using ETicaretAPI.Persistence.Concrete.Repositories.Products;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
          services.AddDbContext<ETicaretAPIDbContext>(options=>options.UseNpgsql(Configuration.ConnectionString));
          services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
          services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
          services.AddScoped<IOrderReadRepository, OrderReadRepository>();
          services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
          services.AddScoped<IProductReadRepository, ProductReadRepository>();
          services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
