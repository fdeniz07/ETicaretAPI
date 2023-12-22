using ETicaretAPI.Application.Abstracts.Storages;
using ETicaretAPI.Infrastructure.Services.Storages;
using ETicaretAPI.Infrastructure.Services.Storages.Azure;
using ETicaretAPI.Infrastructure.Services.Storages.Local;
using ETicaretAPI.Infrastructure.Enums;
using Microsoft.Extensions.DependencyInjection;
using ETicaretAPI.Application.Abstracts.Token;
using ETicaretAPI.Infrastructure.Services.Token;

namespace ETicaretAPI.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }

        //Asagidaki metot bir overload olup, tercih edilmemektedir. Aksi durumda koda bagimli kaliriz. Sadece böyle olabilecegini de görmek amaciyla asagidaki kod olusturulmustur
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
