using PayFlow.Application.Dtos;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Validators;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Enums;
using PayFlow.Domain.Interface;

namespace PayFlow.Application.Services;

public class CreateUserService : ICreateUserService
{
    private readonly IUserRepository  _userRepository;

    public CreateUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    public async Task<UserResponseDto> CreateUserAsync(UserRequestDto userRequestDto)
    {
        var errors = new List<string>();

        var (isEmailValid, emailErrors) = EmailValidator.Validate(userRequestDto.Email);
        if (!isEmailValid) errors.AddRange(emailErrors);

        var (isPasswordValid, passwordErrors) = PasswordValidator.Validate(userRequestDto.Password);
        if (!isPasswordValid) errors.AddRange(passwordErrors);

        if (errors.Any())
            throw new ArgumentException(string.Join(" ", errors));
        
        var existingUser = await _userRepository.GetUserByEmailAsync(userRequestDto.Email);
        if (existingUser != null)
            throw new ArgumentException("E-mail ja cadastrado.");

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequestDto.Password);
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = userRequestDto.FullName,
            Email = userRequestDto.Email,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow,
            Role = userRequestDto.Role,
            IsActive = true
        };
        
        await _userRepository.CreateUserAsync(user);
        return new UserResponseDto(user);
    }
}