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
        public async Task<IEnumerable<Course>> GetAsync()
        {
            return await _courseService.GetAll();
        }

        [HttpGet("id")]
        public async Task<IEnumerable<Course>> GetAsync(int id)
        {
            return await _courseService.GetById(id);
        }

        [HttpPost]
        public async Task<int?> Add(Course course)
        {
            return await _courseService.Add(course.Name);
        }

        [HttpPut]
        public async Task<bool> Update(Course course)
        {
            return await _courseService.Update(course);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _courseService.Delete(id);
        }
    }
}
