using AutoMapper;
using DataModels;
using EJournalDAL.Models;

namespace EJournalDAL.MapperProfiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, EJournal_Comment>();
            CreateMap<EJournal_Comment, Comment>();
        }
    }
}
