using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class ExerciseMappingProfile : Profile
    {
        public ExerciseMappingProfile()
        {
            CreateMap<Exercise, GetExercisesByGroupResult>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForPath(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
                .ForPath(dest => dest.IdGroup, opt => opt.MapFrom(src => src.IdGroup))
                .ForPath(dest => dest.Point, opt => opt.MapFrom(src => src))
                .ForPath(dest => dest.ExerciseType, opt => opt.MapFrom(src => src.ExerciseType));
            CreateMap<StudentMark, GetExercisesByGroupResult>()
                .ForPath(dest => dest.IdStudent, opt => opt.MapFrom(src => src))
                .ForPath(dest => dest.Point, opt => opt.MapFrom(src => src.Point));
            CreateMap<Student, GetExercisesByGroupResult>()
                .ForPath(dest => dest.IdStudent, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            CreateMap<GetExercisesByGroupResult, Exercise>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForPath(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
                .ForPath(dest => dest.IdGroup, opt => opt.MapFrom(src => src.IdGroup))
                .ForPath(dest => dest.StudentMarks, opt => opt.MapFrom(src => src))
                .ForPath(dest => dest.ExerciseType, opt => opt.MapFrom(src => src.ExerciseType));
            CreateMap<GetExercisesByGroupResult, StudentMark>()
                .ForPath(dest => dest.Student, opt => opt.MapFrom(src => src))
                .ForPath(dest => dest.Point, opt => opt.MapFrom(src => src.Point));
            CreateMap<GetExercisesByGroupResult, Student>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.IdStudent))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));
        }
    }
}
