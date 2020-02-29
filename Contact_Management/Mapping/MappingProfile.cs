using System;
using AutoMapper;
   
namespace Contact_Management.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Employee, Database.Entities.Contact>().ReverseMap();
            CreateMap<Models.Freelancer, Database.Entities.Contact>().ReverseMap();
            CreateMap<Models.Company, Database.Entities.Company>()
                .ForMember(dest => dest.OtherAdresses,
                    act => act.MapFrom(src => string.Join(";", src.OtherAdresses)))
                .ReverseMap()
                .ForMember(dest => dest.OtherAdresses,
                    act => act.MapFrom(src => src.OtherAdresses.Split(";", StringSplitOptions.None)));

            CreateMap<Database.Entities.Contact, Database.Entities.Contact>();
            CreateMap<Database.Entities.Company, Database.Entities.Company>();
        }
    }
}
