namespace ETicaretAPI.Application.Abstracts.Storages
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get;}
    }
}
