using ETicaretAPI.Application.Abstracts.Services.Authentications;

namespace ETicaretAPI.Application.Abstracts.Services
{
    public interface IAuthService: IExternalAuthentication, IInternalAuthentication
    {
        
    }
}
