using ETicaretAPI.Application.Dtos;

namespace ETicaretAPI.Application.Abstracts.Services.Authentications
{
    public interface IExternalAuthentication
    {
        //Task<Response> - (Request) 

        Task<TokenDto> FacebookLoginAsync(string authToken, int accessTokenLifeTime);

        Task<TokenDto> GoogleLoginAsync(string idToken, int accessTokenLifeTime);

        //Task TwitterLoginAsync();

        //Task MicrosoftLoginAsync();

        //Task GithubLoginAsync();

        //Task DiscordLoginAsync();

        //Task InstagramLoginAsync();

        //Task LinkedinLoginAsync();
    }
}
