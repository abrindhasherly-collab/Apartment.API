using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IMaintenanceRepository
    {
        Task<IEnumerable<Maintenance>> GetAllAsync();

        Task<Maintenance?> GetByIdAsync(int id);

        Task AddAsync(Maintenance maintenance);

        Task UpdateAsync(Maintenance maintenance);

        Task DeleteAsync(int id);
    }
}
