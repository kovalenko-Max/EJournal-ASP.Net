using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<Group, GetAllGroupsResult>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.IdCourse, opt => opt.MapFrom(src => src))
                .ForPath(dest => dest.StudentsCount, opt => opt.MapFrom(src => src.StudentsCount))
                .ForPath(dest => dest.IsFinish, opt => opt.MapFrom(src => src.IsFinish));
            CreateMap<Course, GetAllGroupsResult>()
                .ForPath(dest => dest.IdCourse, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.NameCourse, opt => opt.MapFrom(src => src.Name));

            CreateMap<GetAllGroupsResult, Group>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Course, opt => opt.MapFrom(src => src))
                .ForPath(dest => dest.StudentsCount, opt => opt.MapFrom(src => src.StudentsCount))
                .ForPath(dest => dest.IsFinish, opt => opt.MapFrom(src => src.IsFinish));
            CreateMap<GetAllGroupsResult, Course>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.IdCourse))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.NameCourse));

            CreateMap<Group, GetGroupResult>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.IdCourse, opt => opt.MapFrom(src => src))
                .ForPath(dest => dest.IsFinish, opt => opt.MapFrom(src => src.IsFinish));
            CreateMap<Course, GetGroupResult>()
                .ForPath(dest => dest.IdCourse, opt => opt.MapFrom(src => src.Id));

            CreateMap<GetGroupResult, Group>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Course, opt => opt.MapFrom(src => src))
                .ForPath(dest => dest.IsFinish, opt => opt.MapFrom(src => src.IsFinish));
            CreateMap<GetGroupResult, Course>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.IdCourse));
        }
    }
}
