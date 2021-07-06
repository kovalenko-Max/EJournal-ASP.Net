﻿using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, EJournal_Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.CommentText))
                .ForMember(dest => dest.CommentType, opt => opt.MapFrom(src => src.CommentType));

            CreateMap<EJournal_Comment, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CommentText, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.CommentType, opt => opt.MapFrom(src => src.CommentType));
        }
    }
}
