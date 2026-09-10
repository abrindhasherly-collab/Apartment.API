using ApartmentApplication.DTOs.Flat;
using ApartmentApplication.DTOs.Maintenance;
using ApartmentApplication.DTOs.Parking;
using ApartmentApplication.DTOs.Staff;
using ApartmentDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Flat
            CreateMap<FlatCreateDto, Flat>();
            CreateMap<FlatUpdateDto, Flat>();
            CreateMap<Flat, FlatResponseDto>();

            // Maintenance
            CreateMap<MaintenanceCreateDto, Maintenance>();
            CreateMap<MaintenanceUpdateDto, Maintenance>();
            CreateMap<Maintenance, MaintenanceResponseDto>();

            // Parking
            CreateMap<ParkingCreateDto, Parking>();
            CreateMap<ParkingUpdateDto, Parking>();
            CreateMap<Parking, ParkingResponseDto>();

            // Staff
            CreateMap<StaffCreateDto, Staff>();
            CreateMap<StaffUpdateDto, Staff>();
            CreateMap<Staff, StaffResponseDto>();
        }
    }
}
