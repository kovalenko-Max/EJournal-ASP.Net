using AutoMapper;
using DataModels;
using EJournalDAL.Models;

namespace EJournalDAL.MapperProfiles
{
    class UserRoleMappingProfile : Profile
    {
        public UserRoleMappingProfile()
        {
            CreateMap<UserRole, EJournal_UserRole>();
            CreateMap<EJournal_UserRole, UserRole>();
        }
    }
}
