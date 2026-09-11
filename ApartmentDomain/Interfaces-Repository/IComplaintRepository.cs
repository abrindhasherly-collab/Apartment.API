using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IComplaintRepository
    {
        Task<IEnumerable<ComplaintEntity>> GetAllAsync();

        Task<ComplaintEntity?> GetByIdAsync(int id);

        Task AddAsync(ComplaintEntity complaint);

        Task UpdateAsync(ComplaintEntity complaint);

        Task DeleteAsync(int id);
    }
}
