using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IVisitorRepository
    {
        Task<IEnumerable<Visitor>> GetAllAsync();

        Task<Visitor?> GetByIdAsync(int id);

        Task<Visitor> AddAsync(Visitor visitor);

        Task UpdateAsync(Visitor visitor);

        Task DeleteAsync(int id);
    }
}
