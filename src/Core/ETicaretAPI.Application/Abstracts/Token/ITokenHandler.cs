using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Abstracts.Token
{
    public interface ITokenHandler
    {
        Dtos.TokenDto CreateAccessToken(int second, AppUser user);

        string CreateRefreshToken();
    }
}
