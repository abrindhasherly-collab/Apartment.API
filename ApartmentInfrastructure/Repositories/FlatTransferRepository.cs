using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentInfrastructure.Repositories
{
    public class FlatTransferRepository : IFlatTransferRepository
    {
        private readonly ApartmentDbcontext _context;

        public FlatTransferRepository(ApartmentDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FlatTransfer>> GetAllAsync()
        {
            return await _context.FlatTransfers.ToListAsync();
        }

        public async Task<FlatTransfer?> GetByIdAsync(int id)
        {
            return await _context.FlatTransfers.FindAsync(id);
        }

        public async Task<FlatTransfer> AddAsync(FlatTransfer flatTransfer)
        {
            await _context.FlatTransfers.AddAsync(flatTransfer);
            await _context.SaveChangesAsync();

            return flatTransfer;
        }

        public async Task UpdateAsync(FlatTransfer flatTransfer)
        {
            _context.FlatTransfers.Update(flatTransfer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flatTransfer = await _context.FlatTransfers.FindAsync(id);

            if (flatTransfer != null)
            {
                _context.FlatTransfers.Remove(flatTransfer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
