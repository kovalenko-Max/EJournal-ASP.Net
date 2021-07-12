using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Controllers
{
    [Route("lesson/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILogger<LessonController> _logger;
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService, ILogger<LessonController> logger)
        {
            _lessonService = lessonService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Lesson>> GetAllAsync()
        {
            return await _lessonService.GetAllLessons();
        }

        [HttpGet("lessonByIdGroup")]
        public async Task<IEnumerable<Lesson>> GetLessonByIdAsync(int groupId)
        {
            return await _lessonService.GetLessonByGroupId(groupId);
        }

        [HttpPost]
        public async Task<int?> AddAsync(Lesson lesson)
        {
            return await _lessonService.AddLesson(lesson);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int lessonId)
        {
            return await _lessonService.DeleteLesson(lessonId);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Lesson lesson)
        {
            return await _lessonService.UpdateLesson(lesson);
        }
    }
}
