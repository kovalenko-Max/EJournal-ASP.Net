using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, GetAllStudentsResult>();
            CreateMap<GetAllStudentsResult, Student>();

            CreateMap<Student, GetStudentResult>();
            CreateMap<GetStudentResult, Student>();

            CreateMap<Student, GetGroupAndStudentsInItResult>();
            CreateMap<GetGroupAndStudentsInItResult, Student>();
        }
    }
}
