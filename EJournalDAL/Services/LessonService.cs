using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DataModels.EJournalDBStoredProcedures;

namespace EJournalDAL.Services
{
    public class LessonService : ILessonService
    {
        private readonly EJournalDB _dbConnection;
        private readonly IMapper _mapper;

        public LessonService(IMapper mapper, EJournalDB dbConnection)
        {
            _mapper = mapper;
            _dbConnection = dbConnection;
        }

        public async Task<int> AddLesson(Lesson lesson)
        {
            return _dbConnection.AddLesson(lesson.Topic, lesson.DateLesson, lesson.IdGroup);
        }

        public async Task<bool> DeleteLesson(int lessonId)
        {
            int result = _dbConnection.DeleteLessonAndStudentsAttendances(lessonId);

            return result > 0;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessons()
        {
            var lessons = new List<GetLessonsResult>(_dbConnection.GetLessons());

            return _mapper.Map<IEnumerable<Lesson>>(lessons);
        }

        public async Task<IEnumerable<Lesson>> GetLessonByGroupId(int idGroup)
        {
            var lessons = new List<GetLessonResult>(_dbConnection.GetLesson(idGroup));

            return _mapper.Map<List<Lesson>>(lessons);
        }

        public async Task<bool> UpdateLesson(Lesson lesson)
        {
            int result = _dbConnection.UpdateLesson(lesson.Id, lesson.Topic, lesson.DateLesson, lesson.IdGroup);

            return result > 0;
        }
    }
}
