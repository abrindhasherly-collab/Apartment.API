using ApartmentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Interfaces_Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentEntity>> GetAllAsync();

        Task<PaymentEntity?> GetByIdAsync(int id);

        Task AddAsync(PaymentEntity payment);

        Task UpdateAsync(PaymentEntity payment);

        Task DeleteAsync(int id);
    }
}
