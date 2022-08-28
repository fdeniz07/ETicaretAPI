using ETicaretAPI.Application.Dtos.User;

namespace ETicaretAPI.Application.Abstracts.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
    }
}
