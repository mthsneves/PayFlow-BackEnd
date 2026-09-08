using PayFlow.Application.Dtos;

namespace PayFlow.Application.Interfaces;

public interface ICreateUserService
{
    Task<UserResponseDto> CreateUserAsync(UserRequestDto userRequestDto);
}