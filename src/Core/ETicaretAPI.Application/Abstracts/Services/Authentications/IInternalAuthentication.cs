using ETicaretAPI.Application.Dtos;

namespace ETicaretAPI.Application.Abstracts.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<TokenDto> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
    }
}
