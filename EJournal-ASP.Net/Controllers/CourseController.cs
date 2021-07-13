using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService, ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseService.GetAll();
        }

        [HttpGet("id")]
        public async Task<IEnumerable<Course>> GetCourseByIdAsync(int id)
        {
            return await _courseService.GetById(id);
        }

        [HttpPost]
        public async Task<int?> AddAsync(Course course)
        {
            return await _courseService.Add(course.Name);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Course course)
        {
            return await _courseService.Update(course);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _courseService.Delete(id);
        }
    }
}
