using ETicaretAPI.Application.Abstracts.Storages;
using ETicaretAPI.Infrastructure.Concretes.Storages;
using ETicaretAPI.Infrastructure.Concretes.Storages.Azure;
using ETicaretAPI.Infrastructure.Concretes.Storages.Local;
using ETicaretAPI.Infrastructure.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }

        //Asagidaki metot bir overload olup, tercih edilmemektedir. Aksi durumda koda bagimli kaliriz. Sadece böyle olabilecegini de görmek amaciyla asagidaki kod olusturulmustur
        public static void AddStorage(this IServiceCollection services, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    services.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
