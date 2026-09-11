using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Repositories
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly ApartmentDbcontext _context;

        public ResidentRepository(ApartmentDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResidentEntity>> GetAllAsync()
        {
            return await _context.Residents
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ResidentEntity?> GetByIdAsync(int id)
        {
            return await _context.Residents
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(ResidentEntity resident)
        {
            await _context.Residents.AddAsync(resident);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ResidentEntity resident)
        {
            _context.Residents.Update(resident);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var resident = await _context.Residents
                .FirstOrDefaultAsync(r => r.Id == id);

            if (resident != null)
            {
                _context.Residents.Remove(resident);

                await _context.SaveChangesAsync();
            }
        }

    }
}
