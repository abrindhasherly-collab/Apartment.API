using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllAsync();

        Task<Staff?> GetByIdAsync(int id);

        Task AddAsync(Staff staff);

        Task UpdateAsync(Staff staff);

        Task DeleteAsync(int id);
    }
}
