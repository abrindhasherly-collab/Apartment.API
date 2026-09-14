using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IResidentRepository
    {
        Task<IEnumerable<ResidentEntity>> GetAllAsync();

        Task<ResidentEntity?> GetByIdAsync(int id);

        Task AddAsync(ResidentEntity resident);

        Task UpdateAsync(ResidentEntity resident);

        Task DeleteAsync(int id);
    }
}
