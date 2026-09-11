using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IEmergencyRepository
    {
        Task<IEnumerable<EmergencyEntity>> GetAllAsync();

        Task<EmergencyEntity?> GetByIdAsync(int id);

        Task AddAsync(EmergencyEntity emergency);

        Task UpdateAsync(EmergencyEntity emergency);

        Task DeleteAsync(int id);
    }
}
