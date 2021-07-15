using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Controllers
{
    [Route("[controller]")]
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
            _logger.LogInformation("GetAllAsync() was called");

            return await _lessonService.GetAllLessons();
        }

        [HttpGet("{idGroup}")]
        public async Task<IEnumerable<Lesson>> GetLessonByIdAsync(int idGroup)
        {
            IEnumerable<Lesson> result = null;

            try
            {
                if (idGroup > 0)
                {
                    _logger.LogInformation("GetLessonByIdAsync() was called");

                    return await _lessonService.GetLessonByGroupId(idGroup);
                }
                else
                {
                    _logger.LogInformation($"Id ({idGroup}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result != null)
            {
                _logger.LogInformation($"Lesson of group by Id ({idGroup}) were received");
            }

            return result;
        }

        [HttpPost]
        public async Task<int?> AddAsync(Lesson lesson)
        {
            _logger.LogInformation("AddAsync() was called");

            return await _lessonService.AddLesson(lesson);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int idLesson)
        {
            bool result = false;

            try
            {
                if (idLesson > 0)
                {
                    _logger.LogInformation("DeleteAsync() was called");

                    return await _lessonService.DeleteLesson(idLesson);
                }
                else
                {
                    _logger.LogInformation($"Id ({idLesson}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result)
            {
                _logger.LogInformation($"Lesson ({idLesson}) was deleted");
            }

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Lesson lesson)
        {
            _logger.LogInformation("UpdateAsync() was called");

            return await _lessonService.UpdateLesson(lesson);
        }
    }
}
