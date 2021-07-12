using AutoMapper;
using EJournalDAL.Models;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class ExerciseMappingProfile: Profile
    {
        public ExerciseMappingProfile()
        {
            CreateMap<Exercise, GetExercisesByGroupResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
                .ForMember(dest => dest.ExerciseType, opt => opt.MapFrom(src => src.ExerciseType))
                .ForMember(dest => dest.IdGroup, opt => opt.MapFrom(src => src.IdGroup))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<GetExercisesByGroupResult, Exercise>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
                .ForMember(dest => dest.ExerciseType, opt => opt.MapFrom(src => src.ExerciseType))
                .ForMember(dest => dest.IdGroup, opt => opt.MapFrom(src => src.IdGroup))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
