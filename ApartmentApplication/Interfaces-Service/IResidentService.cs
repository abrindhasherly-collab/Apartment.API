using ApartmentApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Interfaces_Service
{
    public interface IResidentService
    {

        Task<IEnumerable<ResidentDto>> GetAllAsync();

        Task<ResidentDto?> GetByIdAsync(int id);

        Task<ResidentDto> CreateAsync(CreateResidentDto dto);

        Task<ResidentDto?> UpdateAsync(
            int id,
            UpdateResidentDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
