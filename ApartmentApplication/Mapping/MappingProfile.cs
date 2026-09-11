using ApartmentApplication.DTOs;
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
            // Maintenance
            //CreateMap<Maintenance, MaintenanceDto>();
            //CreateMap<CreateMaintenanceDto, Maintenance>();
            //CreateMap<UpdateMaintenanceDto, Maintenance>();

            // Payment
            CreateMap<PaymentEntity, PaymentDto>().ReverseMap();
            CreateMap<CreatePaymentDto, PaymentEntity>().ReverseMap();
            CreateMap<UpdatePaymentDto, PaymentEntity>().ReverseMap();

            // Complaint
            CreateMap<ComplaintEntity, ComplaintDto>().ReverseMap();
            CreateMap<CreateComplaintDto, ComplaintEntity>().ReverseMap();
            CreateMap<UpdateComplaintDto, ComplaintEntity>().ReverseMap();

            // Emergency
            CreateMap<EmergencyEntity, EmergencyDto>().ReverseMap();
            CreateMap<CreateEmergencyDto, EmergencyEntity>().ReverseMap();
            CreateMap<UpdateEmergencyDto, EmergencyEntity>().ReverseMap();

            // Resident
            CreateMap<ResidentEntity, ResidentDto>().ReverseMap();
            CreateMap<CreateResidentDto, ResidentEntity>().ReverseMap();
            CreateMap<UpdateResidentDto, ResidentEntity>().ReverseMap();
        }
    }
}
