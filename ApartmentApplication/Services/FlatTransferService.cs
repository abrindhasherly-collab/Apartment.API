using ApartmentApplication.DTOs.FlatTransfer;
using ApartmentApplication.Interfaces_Service;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;

namespace ApartmentApplication.Services
{
    public class FlatTransferService : IFlatTransferService
    {
        private readonly IFlatTransferRepository _repository;

        public FlatTransferService(IFlatTransferRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FlatTransferDto>> GetAllAsync()
        {
            var transfers = await _repository.GetAllAsync();

            return transfers.Select(t => new FlatTransferDto
            {
                Id = t.Id,
                FlatId = t.FlatId,
                FromResidentId = t.FromResidentId,
                ToResidentId = t.ToResidentId,
                TransferDate = t.TransferDate,
                Reason = t.Reason,
                Status = t.Status
            });
        }

        public async Task<FlatTransferDto?> GetByIdAsync(int id)
        {
            var transfer = await _repository.GetByIdAsync(id);

            if (transfer == null)
                return null;

            return new FlatTransferDto
            {
                Id = transfer.Id,
                FlatId = transfer.FlatId,
                FromResidentId = transfer.FromResidentId,
                ToResidentId = transfer.ToResidentId,
                TransferDate = transfer.TransferDate,
                Reason = transfer.Reason,
                Status = transfer.Status
            };
        }

        public async Task<FlatTransferDto> CreateAsync(CreateFlatTransferDto dto)
        {
            var transfer = new FlatTransfer
            {
                FlatId = dto.FlatId,
                FromResidentId = dto.FromResidentId,
                ToResidentId = dto.ToResidentId,
                TransferDate = dto.TransferDate,
                Reason = dto.Reason,
                Status = dto.Status
            };

            var created = await _repository.AddAsync(transfer);

            return new FlatTransferDto
            {
                Id = created.Id,
                FlatId = created.FlatId,
                FromResidentId = created.FromResidentId,
                ToResidentId = created.ToResidentId,
                TransferDate = created.TransferDate,
                Reason = created.Reason,
                Status = created.Status
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateFlatTransferDto dto)
        {
            var transfer = await _repository.GetByIdAsync(id);

            if (transfer == null)
                return false;

            transfer.FlatId = dto.FlatId;
            transfer.FromResidentId = dto.FromResidentId;
            transfer.ToResidentId = dto.ToResidentId;
            transfer.TransferDate = dto.TransferDate;
            transfer.Reason = dto.Reason;
            transfer.Status = dto.Status;

            await _repository.UpdateAsync(transfer);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transfer = await _repository.GetByIdAsync(id);

            if (transfer == null)
                return false;

            await _repository.DeleteAsync(id);

            return true;
        }
    }
}