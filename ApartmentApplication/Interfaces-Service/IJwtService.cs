using ApartmentDomain.Entities;

namespace ApartmentApplication.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}