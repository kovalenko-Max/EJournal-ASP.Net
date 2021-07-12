using AutoMapper;
using EJournalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.MapperProfiles
{
   public class StudentMappingProfile :Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, GetAllStudentsResult>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Git, opt => opt.MapFrom(src => src.Git))
               .ForMember(dest => dest.Ranking, opt => opt.MapFrom(src => src.Ranking))
               .ForMember(dest => dest.TeacherAssessment, opt => opt.MapFrom(src => src.TeacherAssessment))
               .ForMember(dest => dest.AgreementNumber, opt => opt.MapFrom(src => src.AgreementNumber));

            CreateMap<GetAllStudentsResult, Student>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Git, opt => opt.MapFrom(src => src.Git))
                .ForMember(dest => dest.Ranking, opt => opt.MapFrom(src => src.Ranking))
                .ForMember(dest => dest.TeacherAssessment, opt => opt.MapFrom(src => src.TeacherAssessment))
                .ForMember(dest => dest.AgreementNumber, opt => opt.MapFrom(src => src.AgreementNumber));

            CreateMap<Student, GetStudentResult>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
              .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Git, opt => opt.MapFrom(src => src.Git))
              .ForMember(dest => dest.Ranking, opt => opt.MapFrom(src => src.Ranking))
              .ForMember(dest => dest.TeacherAssessment, opt => opt.MapFrom(src => src.TeacherAssessment))
              .ForMember(dest => dest.AgreementNumber, opt => opt.MapFrom(src => src.AgreementNumber));


            CreateMap<GetStudentResult, Student>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
              .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Git, opt => opt.MapFrom(src => src.Git))
              .ForMember(dest => dest.Ranking, opt => opt.MapFrom(src => src.Ranking))
              .ForMember(dest => dest.TeacherAssessment, opt => opt.MapFrom(src => src.TeacherAssessment))
              .ForMember(dest => dest.AgreementNumber, opt => opt.MapFrom(src => src.AgreementNumber));

            CreateMap<Student, GetGroupAndStudentsInItResult>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
             .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.Git, opt => opt.MapFrom(src => src.Git))
             .ForMember(dest => dest.AgreementNumber, opt => opt.MapFrom(src => src.AgreementNumber));


            CreateMap<GetGroupAndStudentsInItResult, Student>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
              .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Git, opt => opt.MapFrom(src => src.Git))
              .ForMember(dest => dest.AgreementNumber, opt => opt.MapFrom(src => src.AgreementNumber));
        }
    }
}
