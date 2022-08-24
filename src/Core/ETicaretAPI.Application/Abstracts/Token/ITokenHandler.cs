namespace ETicaretAPI.Application.Abstracts.Token
{
    public interface ITokenHandler
    {
        Dtos.Token CreateAccessToken(int minute);
    }
}
