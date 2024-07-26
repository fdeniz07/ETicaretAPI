using ETicaretAPI.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace ETicaretAPI.SignalR.Extensions
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<ProductHub>("/product-hub");
        }
    }
}
