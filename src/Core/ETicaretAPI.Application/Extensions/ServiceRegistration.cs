using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
