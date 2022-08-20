using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string NameSurname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}

//Frontend
//nameSurname: string;
//userName: string;
//email: string;
//password: string;
//passwordConfirm: string;