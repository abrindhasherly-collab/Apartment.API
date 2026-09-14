using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IParkingRepository
    {
        Task<IEnumerable<Parking>> GetAllAsync();

        Task<Parking?> GetByIdAsync(int id);

        Task AddAsync(Parking parking);

        Task UpdateAsync(Parking parking);

        Task DeleteAsync(int id);
    }
}
