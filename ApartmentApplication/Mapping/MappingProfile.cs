using ApartmentApplication.DTOs;
using ApartmentApplication.DTOs.Building;
using ApartmentApplication.DTOs.Document;
using ApartmentApplication.DTOs.Flat;
using ApartmentApplication.DTOs.Maintenance;
using ApartmentApplication.DTOs.Notice;
using ApartmentApplication.DTOs.Parking;
using ApartmentApplication.DTOs.Staff;
using ApartmentApplication.DTOs.User;
using ApartmentDomain.Entities;
using ApartmentManagement.Application.DTOs.Complaint;
using ApartmentManagement.Application.DTOs.Emergency;
using ApartmentManagement.Application.DTOs.Payment;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

//using ApartmentManagement.Application.DTOs.Complaint;
//using ApartmentManagement.Application.DTOs.Emergency;
//using ApartmentManagement.Application.DTOs.Maintenance;
//using ApartmentManagement.Application.DTOs.Payment;
//using ApartmentManagement.Application.DTOs.Resident;
//using ApartmentManagement.Domain.Entities;
//using AutoMapper;


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
            //CreateMap<Maintenance, MaintenanceDto>();
            //CreateMap<CreateMaintenanceDto, Maintenance>();
            //CreateMap<UpdateMaintenanceDto, Maintenance>();

            CreateMap<RegisterUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserResponseDto>();
            // Payment
            CreateMap<PaymentEntity, PaymentDto>().ReverseMap();
            CreateMap<CreatePaymentDto, PaymentEntity>().ReverseMap();
            CreateMap<UpdatePaymentDto, PaymentEntity>().ReverseMap();

            // Complaint
            CreateMap<ComplaintEntity, ComplaintDto>().ReverseMap();
            CreateMap<CreateComplaintDto, ComplaintEntity>().ReverseMap();
            CreateMap<UpdateComplaintDto, ComplaintEntity>().ReverseMap();
            CreateMap<CreateBuildingDto, Building>();
            CreateMap<UpdateBuildingDto, Building>();
            CreateMap<Building, BuildingResponseDto>();

            // Emergency
            CreateMap<EmergencyEntity, EmergencyDto>().ReverseMap();
            CreateMap<CreateEmergencyDto, EmergencyEntity>().ReverseMap();
            CreateMap<UpdateEmergencyDto, EmergencyEntity>().ReverseMap();
            CreateMap<CreateNoticeDto, Notice>();
            CreateMap<UpdateNoticeDto, Notice>();
            CreateMap<Notice, NoticeResponseDto>();

            // Resident
            CreateMap<ResidentEntity, ResidentDto>().ReverseMap();
            CreateMap<CreateResidentDto, ResidentEntity>().ReverseMap();
            CreateMap<UpdateResidentDto, ResidentEntity>().ReverseMap();
            CreateMap<CreateDocumentDto, Document>();
            CreateMap<UpdateDocumentDto, Document>();
            CreateMap<Document, DocumentResponseDto>();
        }
    }
}
