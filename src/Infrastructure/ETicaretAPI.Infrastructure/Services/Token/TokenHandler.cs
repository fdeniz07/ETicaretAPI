using ETicaretAPI.Application.Abstracts.Token;
using ETicaretAPI.Application.Dtos;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ETicaretAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.Dtos.TokenDto CreateAccessToken(int second, AppUser user)
        {
            Application.Dtos.TokenDto token = new();

            //Security Key'in simetrigini aliyoruz
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Sifrelenmis kimligi olusturuyoruz
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //Olusturulacak Token ayarlarini veriyoruz
            token.Expiration = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) }
                );

            //Token olusturucu sinifindan bir örnek alalim
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            //string refreshToken = CreateRefreshToken();
            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];

            //IDisposable türünde olan nesneler kullanilirken using ile kullanilirlar. Eger ilgili nesneden sonra baska fonksiyonlar kullanilacaksa {} tirnakli versiyonu tercih edilebilir. Ilgili scope kapandiktan sonra bu metot hafizadan cikartilir.

            //using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            //{

            //}

            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);

        }
    }
}
