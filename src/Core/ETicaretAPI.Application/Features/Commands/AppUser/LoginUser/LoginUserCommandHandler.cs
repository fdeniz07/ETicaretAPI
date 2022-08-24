using ETicaretAPI.Application.Abstracts.Token;
using ETicaretAPI.Application.Dtos;
using ETicaretAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using I = ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<I.AppUser> _userManager;
        readonly SignInManager<I.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;


        public LoginUserCommandHandler(UserManager<I.AppUser> userManager, SignInManager<I.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            I.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded) // Authentication basarili
            {
                //...... Yetkileri belirlememiz gerekiyor
                Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };
            }

            // Alternatif 1: Ilgili response siniflarini alt siniflara parcalayarak Success ve Error siniflari üzerinden kullaniciya mesaj verilebilir 

            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = "Kullanıcı veya şifre hatalı..."
            //};

            // Alternatif 2: Exception siniflari üzerinden constructor üzerinden de kullanciya hata mesaji döndürülebilir

            throw new AuthenticationErrorException();
        }
    }
}
