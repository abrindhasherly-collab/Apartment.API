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
        private readonly ApartmentDbcontext _context;

        public ParkingRepository(ApartmentDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parking>> GetAllAsync()
        {
            return await _context.Qwin9Parkings
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Parking?> GetByIdAsync(int id)
        {
            return await _context.Qwin9Parkings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Parking parking)
        {
            await _context.Qwin9Parkings.AddAsync(parking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parking parking)
        {
            _context.Qwin9Parkings.Update(parking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parking = await _context.Qwin9Parkings.FindAsync(id);

            if (parking != null)
            {
                _context.Qwin9Parkings.Remove(parking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
