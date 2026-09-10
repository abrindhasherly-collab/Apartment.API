using ApartmentApplication.DTOs.Staff;
using ApartmentApplication.Interfaces_Service;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;

        public StaffService(
            IStaffRepository staffRepository,
            IMapper mapper)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StaffResponseDto>> GetAllAsync()
        {
            var staff = await _staffRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<StaffResponseDto>>(staff);
        }

        public async Task<StaffResponseDto?> GetByIdAsync(int id)
        {
            var staff = await _staffRepository.GetByIdAsync(id);

            if (staff == null)
            {
                return null;
            }

            return _mapper.Map<StaffResponseDto>(staff);
        }

        public async Task<StaffResponseDto> CreateAsync(
            StaffCreateDto dto)
        {
            var staff = _mapper.Map<Staff>(dto);

            await _staffRepository.AddAsync(staff);

            return _mapper.Map<StaffResponseDto>(staff);
        }

        public async Task<StaffResponseDto?> UpdateAsync(
            int id,
            StaffUpdateDto dto)
        {
            var staff = await _staffRepository.GetByIdAsync(id);

            if (staff == null)
            {
                return null;
            }

            _mapper.Map(dto, staff);

            staff.Id = id;

            await _staffRepository.UpdateAsync(staff);

            return _mapper.Map<StaffResponseDto>(staff);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var staff = await _staffRepository.GetByIdAsync(id);

            if (staff == null)
            {
                return false;
            }

            await _staffRepository.DeleteAsync(id);

            return true;
        }
    }
}
