using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentInfrastructure.Repositories
{
    public class FlatRepository : IFlatRepository
    {
        private readonly ApartmentDbContext _context;

        public FlatRepository(ApartmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flat>> GetAllAsync()
        {
            return await _context.Flats
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Flat?> GetByIdAsync(int id)
        {
            return await _context.Flats
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Flat flat)
        {
            await _context.Flats.AddAsync(flat);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Flat flat)
        {
            _context.Flats.Update(flat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flat = await _context.Flats.FindAsync(id);

            if (flat != null)
            {
                _context.Flats.Remove(flat);
                await _context.SaveChangesAsync();
            }
        }
    }
}
