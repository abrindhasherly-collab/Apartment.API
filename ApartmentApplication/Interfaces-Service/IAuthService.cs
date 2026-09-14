using ApartmentApplication.DTOs.User;

namespace ApartmentApplication.Interfaces;

public interface IAuthService
{
    Task<UserResponseDto?> RegisterAsync(RegisterUserDto dto);

    Task<string?> LoginAsync(LoginDto dto);
}