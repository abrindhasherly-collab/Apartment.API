using ApartmentApplication.DTOs.ParcelDelivery;

namespace ApartmentApplication.Interfaces_Service
{
    public interface IParcelDeliveryService
    {
        Task<IEnumerable<ParcelDeliveryDto>> GetAllAsync();

        Task<ParcelDeliveryDto?> GetByIdAsync(int id);

        Task<ParcelDeliveryDto> CreateAsync(CreateParcelDeliveryDto dto);

        Task<bool> UpdateAsync(int id, UpdateParcelDeliveryDto dto);

        Task<bool> DeleteAsync(int id);
    }
}