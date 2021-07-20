using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<Lesson, GetLessonResult>();
            CreateMap<GetLessonResult, Lesson>();

            CreateMap<Lesson, GetLessonsResult>();
            CreateMap<GetLessonsResult, Lesson>();
        }
    }
}
