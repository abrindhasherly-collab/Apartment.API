using ApartmentApplication.DTOs.Building;
using ApartmentApplication.DTOs.Document;
using ApartmentApplication.DTOs.Notice;
using ApartmentApplication.DTOs.User;
using ApartmentDomain.Entities;
using AutoMapper;

namespace ApartmentApplication.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
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