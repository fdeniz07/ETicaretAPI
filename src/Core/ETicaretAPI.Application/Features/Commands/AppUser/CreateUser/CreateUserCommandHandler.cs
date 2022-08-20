using ETicaretAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using AU = ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<AU.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AU.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                Email = request.Email
            }, request.Password);

            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";

            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;

            //throw new UserCreateFailedException();
        }
    }
}
