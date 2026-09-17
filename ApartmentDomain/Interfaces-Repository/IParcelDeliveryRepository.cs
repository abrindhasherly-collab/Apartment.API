using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IParcelDeliveryRepository
    {
        Task<IEnumerable<ParcelDelivery>> GetAllAsync();

        Task<ParcelDelivery?> GetByIdAsync(int id);

        Task<ParcelDelivery> AddAsync(ParcelDelivery parcelDelivery);

        Task UpdateAsync(ParcelDelivery parcelDelivery);

        Task DeleteAsync(int id);
    }
}
