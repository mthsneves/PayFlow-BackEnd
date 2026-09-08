using PayFlow.Domain.Enums;

namespace PayFlow.Application.Dtos;

public class UserRequestDto
{
    public string FullName  { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}