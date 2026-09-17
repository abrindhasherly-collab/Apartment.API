using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentInfrastructure.Repositories
{
    public class ParcelDeliveryRepository : IParcelDeliveryRepository
    {
        private readonly ApartmentDbContext _context;

        public ParcelDeliveryRepository(ApartmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParcelDelivery>> GetAllAsync()
        {
            return await _context.ParcelDeliveries.ToListAsync();
        }

        public async Task<ParcelDelivery?> GetByIdAsync(int id)
        {
            return await _context.ParcelDeliveries.FindAsync(id);
        }

        public async Task<ParcelDelivery> AddAsync(ParcelDelivery parcelDelivery)
        {
            await _context.ParcelDeliveries.AddAsync(parcelDelivery);
            await _context.SaveChangesAsync();

            return parcelDelivery;
        }

        public async Task UpdateAsync(ParcelDelivery parcelDelivery)
        {
            _context.ParcelDeliveries.Update(parcelDelivery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parcelDelivery = await _context.ParcelDeliveries.FindAsync(id);

            if (parcelDelivery != null)
            {
                _context.ParcelDeliveries.Remove(parcelDelivery);
                await _context.SaveChangesAsync();
            }
        }
    }
}
