using ApartmentApplication.DTOs.Maintenance;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Interfaces_Service
{
    public interface IMaintenanceService
    {
        Task<IEnumerable<MaintenanceResponseDto>> GetAllAsync();

        Task<MaintenanceResponseDto?> GetByIdAsync(int id);

        Task<MaintenanceResponseDto> CreateAsync(MaintenanceCreateDto dto);

        Task<MaintenanceResponseDto?> UpdateAsync(
            int id,
            MaintenanceUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
