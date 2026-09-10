using ApartmentApplication.DTOs.Building;
using ApartmentApplication.DTOs.Document;
using ApartmentApplication.DTOs.Flat;
using ApartmentApplication.DTOs.Maintenance;
using ApartmentApplication.DTOs.Notice;
using ApartmentApplication.DTOs.Parking;
using ApartmentApplication.DTOs.Staff;
using ApartmentApplication.DTOs.User;
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

            CreateMap<RegisterUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserResponseDto>();

            CreateMap<CreateBuildingDto, Building>();
            CreateMap<UpdateBuildingDto, Building>();
            CreateMap<Building, BuildingResponseDto>();

            CreateMap<CreateNoticeDto, Notice>();
            CreateMap<UpdateNoticeDto, Notice>();
            CreateMap<Notice, NoticeResponseDto>();

            CreateMap<CreateDocumentDto, Document>();
            CreateMap<UpdateDocumentDto, Document>();
            CreateMap<Document, DocumentResponseDto>();
        }
    }
}
