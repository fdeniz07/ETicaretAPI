using ETicaretAPI.Application.Dtos;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {

    }

    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public TokenDto Token { get; set; }
    }

    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}

