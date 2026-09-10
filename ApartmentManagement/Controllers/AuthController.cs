using ApartmentApplication.DTOs.User;
using ApartmentApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterUserDto dto)
    {
        var result =
            await _authService.RegisterAsync(dto);

        if (result == null)
        {
            return BadRequest(
                "Email is already registered.");
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginDto dto)
    {
        var token =
            await _authService.LoginAsync(dto);

        if (token == null)
        {
            return Unauthorized(
                "Invalid email or password.");
        }

        return Ok(new
        {
            message = "Login successful",
            token = token
        });
    }
}