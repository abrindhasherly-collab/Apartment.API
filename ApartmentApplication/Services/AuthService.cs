using ApartmentApplication.DTOs.User;
using ApartmentApplication.Interfaces;
using ApartmentDomain.Entities;
using ApartmentDomain.Enums;
using ApartmentDomain.Interfaces;
using AutoMapper;

namespace ApartmentApplication.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public AuthService(
        IUserRepository userRepository,
        IJwtService jwtService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<UserResponseDto?> RegisterAsync(
        RegisterUserDto dto)
    {
        var existingUser =
            await _userRepository.GetByEmailAsync(dto.Email);

        if (existingUser != null)
        {
            return null;
        }

        var user = _mapper.Map<User>(dto);

        user.Status = UserStatus.Active;
        user.CreatedDate = DateTime.UtcNow;

        var createdUser =
            await _userRepository.AddAsync(user);

        return _mapper.Map<UserResponseDto>(createdUser);
    }

    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var user =
            await _userRepository.GetByEmailAsync(dto.Email);

        if (user == null)
        {
            return null;
        }

        if (user.Status != UserStatus.Active)
        {
            return null;
        }

        if (user.Password != dto.Password)
        {
            return null;
        }

        return _jwtService.GenerateToken(user);
    }
}