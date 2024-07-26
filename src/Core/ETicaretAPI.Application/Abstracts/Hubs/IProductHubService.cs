namespace ETicaretAPI.Application.Abstracts.Hubs
{
    public interface IProductHubService
    {
        Task ProductAddedMessageAsync(string message);
    }
}
