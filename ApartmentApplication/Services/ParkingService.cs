using ApartmentApplication.DTOs.Parking;
using ApartmentApplication.Interfaces_Service;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IMapper _mapper;

        public ParkingService(
            IParkingRepository parkingRepository,
            IMapper mapper)
        {
            _parkingRepository = parkingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParkingResponseDto>> GetAllAsync()
        {
            var parkings = await _parkingRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ParkingResponseDto>>(
                parkings);
        }

        public async Task<ParkingResponseDto?> GetByIdAsync(int id)
        {
            var parking =
                await _parkingRepository.GetByIdAsync(id);

            if (parking == null)
            {
                return null;
            }

            return _mapper.Map<ParkingResponseDto>(parking);
        }

        public async Task<ParkingResponseDto> CreateAsync(
            ParkingCreateDto dto)
        {
            var parking = _mapper.Map<Parking>(dto);

            await _parkingRepository.AddAsync(parking);

            return _mapper.Map<ParkingResponseDto>(parking);
        }

        public async Task<ParkingResponseDto?> UpdateAsync(
            int id,
            ParkingUpdateDto dto)
        {
            var parking =
                await _parkingRepository.GetByIdAsync(id);

            if (parking == null)
            {
                return null;
            }

            _mapper.Map(dto, parking);

            parking.Id = id;

            await _parkingRepository.UpdateAsync(parking);

            return _mapper.Map<ParkingResponseDto>(parking);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parking =
                await _parkingRepository.GetByIdAsync(id);

            if (parking == null)
            {
                return false;
            }

            await _parkingRepository.DeleteAsync(id);

            return true;
        }
    }
}
