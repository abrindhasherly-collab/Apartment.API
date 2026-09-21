using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentInfrastructure.Repositories
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly ApartmentDbcontext _context;

        public MaintenanceRepository(ApartmentDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Maintenance>> GetAllAsync()
        {
            return await _context.Qwin9Maintenances
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Maintenance?> GetByIdAsync(int id)
        {
            return await _context.Qwin9Maintenances
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Maintenance maintenance)
        {
            await _context.Qwin9Maintenances.AddAsync(maintenance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Maintenance maintenance)
        {
            _context.Qwin9Maintenances.Update(maintenance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var maintenance = await _context.Qwin9Maintenances.FindAsync(id);

            if (maintenance != null)
            {
                _context.Qwin9Maintenances.Remove(maintenance);
                await _context.SaveChangesAsync();
            }
        }
    }
}
