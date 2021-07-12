using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> GetAllLessons();
        Task<IEnumerable<Lesson>> GetLessonByGroupId(int idGroup);
        Task<int> AddLesson(Lesson lesson);
        Task<bool> UpdateLesson(Lesson lesson);
        Task<bool> DeleteLesson(int lessonId);
    }
}
