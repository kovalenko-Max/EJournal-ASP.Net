using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBDBStoredProcedures;

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
