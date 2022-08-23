using MediatR;
using Microsoft.AspNetCore.Identity;
using I= ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<I.AppUser> _userManager;
        readonly SignInManager<I.AppUser> _signInManager;

        public LoginUserCommandHandler(UserManager<I.AppUser> userManager, SignInManager<I.AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            I.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user=await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user == null)
                throw new Exception("Kullanıcı veya şifre hatalı");

            //_signInManager.CheckPasswordSignInAsync();
            return null;
        }
    }
}
