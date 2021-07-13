using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class ExerciseMappingProfile : Profile
    {
        public ExerciseMappingProfile()
        {
            CreateMap<Exercise, GetExercisesByGroupResult>();
            CreateMap<GetExercisesByGroupResult, Exercise>();
        }
    }
}
