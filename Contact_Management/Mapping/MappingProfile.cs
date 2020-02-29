using System;
using System.Linq;
using AutoMapper;
   
namespace Contact_Management.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Controllers.DTO.Request.CompanyCreation, Models.Company>();
            CreateMap<Controllers.DTO.Request.CompanyUpdate, Models.Company>();
            CreateMap<Controllers.DTO.Request.EmployeeCreation, Models.Employee>();
            CreateMap<Controllers.DTO.Request.EmployeeUpdate, Models.Employee>();
            CreateMap<Controllers.DTO.Request.FreelancerCreation, Models.Freelancer>();
            CreateMap<Controllers.DTO.Request.FreelancerUpdate, Models.Freelancer>();

            CreateMap<Controllers.DTO.Request.CompanyCreation, Database.Entities.Company>()
                .ForMember(dest => dest.OtherAdresses,
                    act => act.MapFrom(src => string.Join(";", src.OtherAdresses)));
            CreateMap<Controllers.DTO.Request.CompanyUpdate, Database.Entities.Company>()
                .ForMember(dest => dest.OtherAdresses,
                    act => act.MapFrom(src => string.Join(";", src.OtherAdresses)));
            CreateMap<Controllers.DTO.Request.EmployeeCreation, Database.Entities.Contact>()
                .ForMember(dest => dest.Type, act =>
                    act.MapFrom(src => Database.Entities.Contact.ContactType.Employee));
            CreateMap<Controllers.DTO.Request.EmployeeUpdate, Database.Entities.Contact>()
                .ForMember(dest => dest.Type, act =>
                    act.MapFrom(src => Database.Entities.Contact.ContactType.Employee));
            CreateMap<Controllers.DTO.Request.FreelancerCreation, Database.Entities.Contact>()
                .ForMember(dest => dest.Type, act =>
                    act.MapFrom(src => Database.Entities.Contact.ContactType.Freelancer));
            CreateMap<Controllers.DTO.Request.FreelancerUpdate, Database.Entities.Contact>()
                .ForMember(dest => dest.Type, act =>
                    act.MapFrom(src => Database.Entities.Contact.ContactType.Freelancer));

            CreateMap<Models.Company, Controllers.DTO.Response.Company>();
            CreateMap<Models.Employee, Controllers.DTO.Response.Employee>();
            CreateMap<Models.Freelancer, Controllers.DTO.Response.Freelancer>();
            CreateMap<Models.Employee, Controllers.DTO.Response.Contact>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
                    Controllers.DTO.Response.Contact.ContactType.Employee));
            CreateMap<Models.Freelancer, Controllers.DTO.Response.Contact>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
                    Controllers.DTO.Response.Contact.ContactType.Freelancer));

            CreateMap<Models.Employee, Database.Entities.Contact>().ReverseMap();
            CreateMap<Models.Freelancer, Database.Entities.Contact>().ReverseMap();
            CreateMap<Models.Company, Database.Entities.Company>()
                .ForMember(dest => dest.OtherAdresses,
                    act => act.MapFrom(src => string.Join(";", src.OtherAdresses)))
                .ReverseMap()
                .ForMember(dest => dest.OtherAdresses,
                    act => act.MapFrom(src => src.OtherAdresses.Split(";", StringSplitOptions.None).ToList()));

            CreateMap<Database.Entities.Contact, Database.Entities.Contact>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Database.Entities.Company, Database.Entities.Company>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
