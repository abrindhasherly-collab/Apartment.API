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
        private readonly ApartmentDbcontext _context;

        public FlatRepository(ApartmentDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flat>> GetAllAsync()
        {
            return await _context.Qwin9Flats
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Flat?> GetByIdAsync(int id)
        {
            return await _context.Qwin9Flats
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Flat flat)
        {
            await _context.Qwin9Flats.AddAsync(flat);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Flat flat)
        {
            _context.Qwin9Flats.Update(flat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flat = await _context.Qwin9Flats.FindAsync(id);

            if (flat != null)
            {
                _context.Qwin9Flats.Remove(flat);
                await _context.SaveChangesAsync();
            }
        }
    }
}
