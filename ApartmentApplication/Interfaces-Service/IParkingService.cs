using ApartmentApplication.DTOs.Parking;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Interfaces_Service
{
    public interface IParkingService
    {
        Task<IEnumerable<ParkingResponseDto>> GetAllAsync();

        Task<ParkingResponseDto?> GetByIdAsync(int id);

        Task<ParkingResponseDto> CreateAsync(ParkingCreateDto dto);

        Task<ParkingResponseDto?> UpdateAsync(
            int id,
            ParkingUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
