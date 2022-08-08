using ETicaretAPI.Application.Abstracts.Storages.Azure;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Infrastructure.Concretes.Storages.Azure
{
    public class AzureStorage : IAzureStorage
    {
        public Task DeleteAsync(string fileName, string pathOrContainerName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            throw new NotImplementedException();
        }
    }
}
