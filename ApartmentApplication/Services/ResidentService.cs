using ApartmentApplication.DTOs;
using ApartmentApplication.Interfaces_Service;
using ApartmentDomain.Entities;
using ApartmentDomain.Enums;
using ApartmentDomain.Interfaces_Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Services
{
    public class ResidentService : IResidentService
    {
        private readonly IResidentRepository _repository;
        private readonly IMapper _mapper;

        public ResidentService(IResidentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResidentDto>> GetAllAsync()
        {
            var residents = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<ResidentDto>>(residents);
        }

        public async Task<ResidentDto?> GetByIdAsync(int id)
        {
            var resident = await _repository.GetByIdAsync(id);

            if (resident == null)
            {
                return null;
            }

            return _mapper.Map<ResidentDto>(resident);
        }

        public async Task<ResidentDto> CreateAsync(CreateResidentDto dto)
        {
            var resident = _mapper.Map<ResidentEntity>(dto);

            resident.DateOfJoining = DateTime.UtcNow;
            resident.Status = ResidentStatus.Active;

            await _repository.AddAsync(resident);

            return _mapper.Map<ResidentDto>(resident);
        }

        public async Task<ResidentDto?> UpdateAsync(
            int id,
            UpdateResidentDto dto)
        {
            var existingResident =
                await _repository.GetByIdAsync(id);

            if (existingResident == null)
            {
                return null;
            }

            _mapper.Map(dto, existingResident);

            await _repository.UpdateAsync(existingResident);

            return _mapper.Map<ResidentDto>(existingResident);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var resident = await _repository.GetByIdAsync(id);

            if (resident == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);

            return true;
        }
    }
}
