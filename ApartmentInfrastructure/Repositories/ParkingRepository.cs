using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentInfrastructure.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ApartmentDbContext _context;

        public ParkingRepository(ApartmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parking>> GetAllAsync()
        {
            return await _context.Parkings
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Parking?> GetByIdAsync(int id)
        {
            return await _context.Parkings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Parking parking)
        {
            await _context.Parkings.AddAsync(parking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parking parking)
        {
            _context.Parkings.Update(parking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parking = await _context.Parkings.FindAsync(id);

            if (parking != null)
            {
                _context.Parkings.Remove(parking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
