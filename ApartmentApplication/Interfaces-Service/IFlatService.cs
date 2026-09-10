using ApartmentApplication.DTOs.Flat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Interfaces_Service
{
    public interface IFlatService
    {
        Task<IEnumerable<FlatResponseDto>> GetAllAsync();

        Task<FlatResponseDto?> GetByIdAsync(int id);

        Task<FlatResponseDto> CreateAsync(FlatCreateDto dto);

        Task<FlatResponseDto?> UpdateAsync(int id, FlatUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
