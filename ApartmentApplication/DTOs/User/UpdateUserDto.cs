using ApartmentDomain.Enums;

namespace ApartmentApplication.DTOs.User;

public class UpdateUserDto
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public UserStatus Status { get; set; }
}