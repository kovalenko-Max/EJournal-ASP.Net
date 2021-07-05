using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, GetAllCoursesResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<GetAllCoursesResult, Course>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
