using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IFlatRepository
    {
        Task<IEnumerable<Flat>> GetAllAsync();

        Task<Flat?> GetByIdAsync(int id);

        Task AddAsync(Flat flat);

        Task UpdateAsync(Flat flat);

        Task DeleteAsync(int id);
    }
}
