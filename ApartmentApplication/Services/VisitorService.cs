using ApartmentApplication.DTOs.Visitor;
using ApartmentApplication.Interfaces_Service;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;

namespace ApartmentApplication.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorService(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        public async Task<IEnumerable<VisitorDto>> GetAllAsync()
        {
            var visitors = await _visitorRepository.GetAllAsync();

            return visitors.Select(v => new VisitorDto
            {
                Id = v.Id,
                VisitorName = v.VisitorName,
                Phone = v.Phone,
                VehicleNumber = v.VehicleNumber,
                FlatId = v.FlatId,
                Purpose = v.Purpose,
                VisitDate = v.VisitDate,
                CheckInTime = v.CheckInTime,
                CheckOutTime = v.CheckOutTime,
                Status = v.Status
            });
        }

        public async Task<VisitorDto?> GetByIdAsync(int id)
        {
            var visitor = await _visitorRepository.GetByIdAsync(id);

            if (visitor == null)
                return null;

            return new VisitorDto
            {
                Id = visitor.Id,
                VisitorName = visitor.VisitorName,
                Phone = visitor.Phone,
                VehicleNumber = visitor.VehicleNumber,
                FlatId = visitor.FlatId,
                Purpose = visitor.Purpose,
                VisitDate = visitor.VisitDate,
                CheckInTime = visitor.CheckInTime,
                CheckOutTime = visitor.CheckOutTime,
                Status = visitor.Status
            };
        }

        public async Task<VisitorDto> CreateAsync(CreateVisitorDto dto)
        {
            var visitor = new Visitor
            {
                VisitorName = dto.VisitorName,
                Phone = dto.Phone,
                VehicleNumber = dto.VehicleNumber,
                FlatId = dto.FlatId,
                Purpose = dto.Purpose,
                VisitDate = dto.VisitDate,
                CheckInTime = dto.CheckInTime,
                CheckOutTime = dto.CheckOutTime,
                Status = dto.Status
            };

            var createdVisitor = await _visitorRepository.AddAsync(visitor);

            return new VisitorDto
            {
                Id = createdVisitor.Id,
                VisitorName = createdVisitor.VisitorName,
                Phone = createdVisitor.Phone,
                VehicleNumber = createdVisitor.VehicleNumber,
                FlatId = createdVisitor.FlatId,
                Purpose = createdVisitor.Purpose,
                VisitDate = createdVisitor.VisitDate,
                CheckInTime = createdVisitor.CheckInTime,
                CheckOutTime = createdVisitor.CheckOutTime,
                Status = createdVisitor.Status
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateVisitorDto dto)
        {
            var visitor = await _visitorRepository.GetByIdAsync(id);

            if (visitor == null)
                return false;

            visitor.VisitorName = dto.VisitorName;
            visitor.Phone = dto.Phone;
            visitor.VehicleNumber = dto.VehicleNumber;
            visitor.FlatId = dto.FlatId;
            visitor.Purpose = dto.Purpose;
            visitor.VisitDate = dto.VisitDate;
            visitor.CheckInTime = dto.CheckInTime;
            visitor.CheckOutTime = dto.CheckOutTime;
            visitor.Status = dto.Status;

            await _visitorRepository.UpdateAsync(visitor);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var visitor = await _visitorRepository.GetByIdAsync(id);

            if (visitor == null)
                return false;

            await _visitorRepository.DeleteAsync(id);

            return true;
        }
    }
}