using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, GetAllCoursesResult>();
            CreateMap<GetAllCoursesResult, Course>();

            CreateMap<Course, GetCourseResult>();
            CreateMap<GetCourseResult, Course>();
        }
    }
}
