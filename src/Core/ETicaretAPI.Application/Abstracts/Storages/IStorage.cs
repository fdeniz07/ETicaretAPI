using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Abstracts.Storages
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        Task DeleteAsync(string fileName, string pathOrContainerName);

        List<string> GetFiles(string pathOrContainerName);

        bool HasFile(string pathOrContainerName,string fileName);
    }
}
