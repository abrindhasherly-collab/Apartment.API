using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IFlatTransferRepository
    {
        Task<IEnumerable<FlatTransfer>> GetAllAsync();

        Task<FlatTransfer?> GetByIdAsync(int id);

        Task<FlatTransfer> AddAsync(FlatTransfer flatTransfer);

        Task UpdateAsync(FlatTransfer flatTransfer);

        Task DeleteAsync(int id);
    }
}
