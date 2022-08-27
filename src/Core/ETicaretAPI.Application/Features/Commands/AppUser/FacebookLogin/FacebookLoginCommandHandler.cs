using ETicaretAPI.Application.Abstracts.Token;
using ETicaretAPI.Application.Dtos;
using ETicaretAPI.Application.Dtos.Facebook;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using UM = ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {
        readonly UserManager<UM.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly HttpClient _httpClient;


        public FacebookLoginCommandHandler(UserManager<UM.AppUser> userManager, ITokenHandler tokenHandler, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id=614822086897762&client_secret=8e1dec39640dcf12d7e906a5f3f12ea2&grant_type=client_credentials");

            FacebookAccessTokenResponseDto facebookAccessTokenResponse = JsonSerializer.Deserialize<FacebookAccessTokenResponseDto>(accessTokenResponse);

            string userAccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={request.AuthToken}&access_token={facebookAccessTokenResponse.AccessToken}");

            FacebookUserAccessTokenValidationDto validation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidationDto>(userAccessTokenValidation);

            if (validation.Data.IsValid)
            {
                string userInfoResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={request.AuthToken}");

                FacebookUserInfoResponseDto userInfo = JsonSerializer.Deserialize<FacebookUserInfoResponseDto>(userInfoResponse);



                var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
                UM.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

                bool result = user != null;
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(userInfo.Email); // Eger ilgili sosyal logindeki email, bizim localde tuttugumuz kullanici email adresi ile ayni mi kontrolü
                    if (user == null)
                    {
                        user = new()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = userInfo.Email,
                            UserName = userInfo.Email,
                            NameSurname = userInfo.Name
                        };
                        var identityResult = await _userManager.CreateAsync(user);
                        result = identityResult.Succeeded;
                    }
                }

                if (result)
                {
                    await _userManager.AddLoginAsync(user, info); //AspNetUserLogins

                    TokenDto token = _tokenHandler.CreateAccessToken(5);
                    return new()
                    {
                        Token = token,
                    };
                }
            }
            throw new Exception("Invalid external authentication");
        }
    }
}
