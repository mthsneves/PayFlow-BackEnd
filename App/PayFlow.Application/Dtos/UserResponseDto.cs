using PayFlow.Domain.Entities;
using PayFlow.Domain.Enums;

namespace PayFlow.Application.Dtos;

public class UserResponseDto
{
    public UserResponseDto()
    {
        
    }

    public UserResponseDto(User user)
    {
       Id = user.Id;
       FullName = user.FullName;
       Email = user.Email;
       Role = user.Role;
       CreatedAt = user.CreatedAt;
       
    }
    public Guid Id { get; set; }
    public string FullName  { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt  { get; set; } = DateTime.UtcNow;
}