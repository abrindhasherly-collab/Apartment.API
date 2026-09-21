using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentInfrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApartmentDbcontext _context;

        public StaffRepository(ApartmentDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _context.Qwin9Staffs
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Staff?> GetByIdAsync(int id)
        {
            return await _context.Qwin9Staffs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Staff staff)
        {
            await _context.Qwin9Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Staff staff)
        {
            _context.Qwin9Staffs.Update(staff);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var staff = await _context.Qwin9Staffs.FindAsync(id);

            if (staff != null)
            {
                _context.Qwin9Staffs.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }
    }
}
