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
        private readonly ApartmentDbcontext _context;

        public ParcelDeliveryRepository(ApartmentDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParcelDelivery>> GetAllAsync()
        {
            return await _context.Qwin9ParcelDeliveries.ToListAsync();
        }

        public async Task<ParcelDelivery?> GetByIdAsync(int id)
        {
            return await _context.Qwin9ParcelDeliveries.FindAsync(id);
        }

        public async Task<ParcelDelivery> AddAsync(ParcelDelivery parcelDelivery)
        {
            await _context.Qwin9ParcelDeliveries.AddAsync(parcelDelivery);
            await _context.SaveChangesAsync();

            return parcelDelivery;
        }

        public async Task UpdateAsync(ParcelDelivery parcelDelivery)
        {
            _context.Qwin9ParcelDeliveries.Update(parcelDelivery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parcelDelivery = await _context.Qwin9ParcelDeliveries.FindAsync(id);

            if (parcelDelivery != null)
            {
                _context.Qwin9ParcelDeliveries.Remove(parcelDelivery);
                await _context.SaveChangesAsync();
            }
        }
    }
}
