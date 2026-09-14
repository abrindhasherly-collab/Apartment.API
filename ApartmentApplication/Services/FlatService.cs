using ApartmentApplication.DTOs.Flat;
using ApartmentApplication.Interfaces_Service;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Services
{
    public class FlatService : IFlatService
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IMapper _mapper;

        public FlatService(
            IFlatRepository flatRepository,
            IMapper mapper)
        {
            _flatRepository = flatRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlatResponseDto>> GetAllAsync()
        {
            var flats = await _flatRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<FlatResponseDto>>(flats);
        }

        public async Task<FlatResponseDto?> GetByIdAsync(int id)
        {
            var flat = await _flatRepository.GetByIdAsync(id);

            if (flat == null)
            {
                return null;
            }

            return _mapper.Map<FlatResponseDto>(flat);
        }

        public async Task<FlatResponseDto> CreateAsync(FlatCreateDto dto)
        {
            var flat = _mapper.Map<Flat>(dto);

            await _flatRepository.AddAsync(flat);

            return _mapper.Map<FlatResponseDto>(flat);
        }

        public async Task<FlatResponseDto?> UpdateAsync(
            int id,
            FlatUpdateDto dto)
        {
            var flat = await _flatRepository.GetByIdAsync(id);

            if (flat == null)
            {
                return null;
            }

            _mapper.Map(dto, flat);

            flat.Id = id;

            await _flatRepository.UpdateAsync(flat);

            return _mapper.Map<FlatResponseDto>(flat);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var flat = await _flatRepository.GetByIdAsync(id);

            if (flat == null)
            {
                return false;
            }

            await _flatRepository.DeleteAsync(id);

            return true;
        }
    }
}
