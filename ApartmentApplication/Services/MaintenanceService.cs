using ApartmentApplication.DTOs.Maintenance;
using ApartmentApplication.Interfaces_Service;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;
        private readonly IMapper _mapper;

        public MaintenanceService(
            IMaintenanceRepository maintenanceRepository,
            IMapper mapper)
        {
            _maintenanceRepository = maintenanceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaintenanceResponseDto>> GetAllAsync()
        {
            var maintenances =
                await _maintenanceRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<MaintenanceResponseDto>>(
                maintenances);
        }

        public async Task<MaintenanceResponseDto?> GetByIdAsync(int id)
        {
            var maintenance =
                await _maintenanceRepository.GetByIdAsync(id);

            if (maintenance == null)
            {
                return null;
            }

            return _mapper.Map<MaintenanceResponseDto>(maintenance);
        }

        public async Task<MaintenanceResponseDto> CreateAsync(
            MaintenanceCreateDto dto)
        {
            var maintenance =
                _mapper.Map<Maintenance>(dto);

            await _maintenanceRepository.AddAsync(maintenance);

            return _mapper.Map<MaintenanceResponseDto>(
                maintenance);
        }

        public async Task<MaintenanceResponseDto?> UpdateAsync(
            int id,
            MaintenanceUpdateDto dto)
        {
            var maintenance =
                await _maintenanceRepository.GetByIdAsync(id);

            if (maintenance == null)
            {
                return null;
            }

            _mapper.Map(dto, maintenance);

            maintenance.Id = id;

            await _maintenanceRepository.UpdateAsync(
                maintenance);

            return _mapper.Map<MaintenanceResponseDto>(
                maintenance);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var maintenance =
                await _maintenanceRepository.GetByIdAsync(id);

            if (maintenance == null)
            {
                return false;
            }

            await _maintenanceRepository.DeleteAsync(id);

            return true;
        }
    }
}
