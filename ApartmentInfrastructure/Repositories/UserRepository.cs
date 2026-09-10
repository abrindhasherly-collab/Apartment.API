using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApartmentDbContext _context;

    public UserRepository(ApartmentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user =
            await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            return;
        }

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}