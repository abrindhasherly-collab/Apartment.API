using ApartmentApplication.DTOs.Staff;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Interfaces_Service
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffResponseDto>> GetAllAsync();

        Task<StaffResponseDto?> GetByIdAsync(int id);

        Task<StaffResponseDto> CreateAsync(StaffCreateDto dto);

        Task<StaffResponseDto?> UpdateAsync(
            int id,
            StaffUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
