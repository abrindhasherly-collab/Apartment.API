using ApartmentApplication.DTOs.FlatTransfer;

namespace ApartmentApplication.Interfaces_Service
{
    public interface IFlatTransferService
    {
        Task<IEnumerable<FlatTransferDto>> GetAllAsync();

        Task<FlatTransferDto?> GetByIdAsync(int id);

        Task<FlatTransferDto> CreateAsync(CreateFlatTransferDto dto);

        Task<bool> UpdateAsync(int id, UpdateFlatTransferDto dto);

        Task<bool> DeleteAsync(int id);
    }
}