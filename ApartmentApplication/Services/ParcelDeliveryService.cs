using ApartmentApplication.DTOs.ParcelDelivery;
using ApartmentApplication.Interfaces_Service;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;

namespace ApartmentApplication.Services
{
    public class ParcelDeliveryService : IParcelDeliveryService
    {
        private readonly IParcelDeliveryRepository _repository;

        public ParcelDeliveryService(IParcelDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ParcelDeliveryDto>> GetAllAsync()
        {
            var deliveries = await _repository.GetAllAsync();

            return deliveries.Select(d => new ParcelDeliveryDto
            {
                Id = d.Id,
                FlatId = d.FlatId,
                DeliveryPersonName = d.DeliveryPersonName,
                DeliveryPersonPhone = d.DeliveryPersonPhone,
                TrackingNumber = d.TrackingNumber,
                DeliveryCompany = d.DeliveryCompany,
                DeliveryDate = d.DeliveryDate,
                ReceivedTime = d.ReceivedTime,
                Status = d.Status
            });
        }

        public async Task<ParcelDeliveryDto?> GetByIdAsync(int id)
        {
            var delivery = await _repository.GetByIdAsync(id);

            if (delivery == null)
                return null;

            return new ParcelDeliveryDto
            {
                Id = delivery.Id,
                FlatId = delivery.FlatId,
                DeliveryPersonName = delivery.DeliveryPersonName,
                DeliveryPersonPhone = delivery.DeliveryPersonPhone,
                TrackingNumber = delivery.TrackingNumber,
                DeliveryCompany = delivery.DeliveryCompany,
                DeliveryDate = delivery.DeliveryDate,
                ReceivedTime = delivery.ReceivedTime,
                Status = delivery.Status
            };
        }

        public async Task<ParcelDeliveryDto> CreateAsync(CreateParcelDeliveryDto dto)
        {
            var delivery = new ParcelDelivery
            {
                FlatId = dto.FlatId,
                DeliveryPersonName = dto.DeliveryPersonName,
                DeliveryPersonPhone = dto.DeliveryPersonPhone,
                TrackingNumber = dto.TrackingNumber,
                DeliveryCompany = dto.DeliveryCompany,
                DeliveryDate = dto.DeliveryDate,
                ReceivedTime = dto.ReceivedTime,
                Status = dto.Status
            };

            var created = await _repository.AddAsync(delivery);

            return new ParcelDeliveryDto
            {
                Id = created.Id,
                FlatId = created.FlatId,
                DeliveryPersonName = created.DeliveryPersonName,
                DeliveryPersonPhone = created.DeliveryPersonPhone,
                TrackingNumber = created.TrackingNumber,
                DeliveryCompany = created.DeliveryCompany,
                DeliveryDate = created.DeliveryDate,
                ReceivedTime = created.ReceivedTime,
                Status = created.Status
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateParcelDeliveryDto dto)
        {
            var delivery = await _repository.GetByIdAsync(id);

            if (delivery == null)
                return false;

            delivery.FlatId = dto.FlatId;
            delivery.DeliveryPersonName = dto.DeliveryPersonName;
            delivery.DeliveryPersonPhone = dto.DeliveryPersonPhone;
            delivery.TrackingNumber = dto.TrackingNumber;
            delivery.DeliveryCompany = dto.DeliveryCompany;
            delivery.DeliveryDate = dto.DeliveryDate;
            delivery.ReceivedTime = dto.ReceivedTime;
            delivery.Status = dto.Status;

            await _repository.UpdateAsync(delivery);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var delivery = await _repository.GetByIdAsync(id);

            if (delivery == null)
                return false;

            await _repository.DeleteAsync(id);

            return true;
        }
    }
}