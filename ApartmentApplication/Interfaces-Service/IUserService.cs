using ApartmentApplication.DTOs.User;

namespace ApartmentApplication.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllAsync();

    Task<UserResponseDto?> GetByIdAsync(int id);

    Task<UserResponseDto?> UpdateAsync(
        int id,
        UpdateUserDto dto);

    Task<bool> DeleteAsync(int id);
}