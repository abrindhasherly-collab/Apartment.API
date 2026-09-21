using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Repositories
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly ApartmentDbcontext _context;

        public VisitorRepository(ApartmentDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visitor>> GetAllAsync()
        {
            return await _context.Qwin9Visitors.ToListAsync();
        }

        public async Task<Visitor?> GetByIdAsync(int id)
        {
            return await _context.Qwin9Visitors.FindAsync(id);
        }

        public async Task<Visitor> AddAsync(Visitor visitor)
        {
            await _context.Qwin9Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();

            return visitor;
        }

        public async Task UpdateAsync(Visitor visitor)
        {
            _context.Qwin9Visitors.Update(visitor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var visitor = await _context.Qwin9Visitors.FindAsync(id);

            if (visitor != null)
            {
                _context.Qwin9Visitors.Remove(visitor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
