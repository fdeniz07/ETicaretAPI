namespace ETicaretAPI.Application.Abstracts.Token
{
    public interface ITokenHandler
    {
        Dtos.TokenDto CreateAccessToken(int second);

        string CreateRefreshToken();
    }
}
