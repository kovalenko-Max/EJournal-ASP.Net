using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "BasicUser,Admin")]
        public async Task<IEnumerable<Course>> GetCourseByIdAsync(int id)
        {
            IEnumerable<Course> result = null;

            try
            {
                if (id > 0)
                {
                    _logger.LogInformation("GetCourseByIdAsync() was called");

                    result = await _courseService.GetById(id);
                }
                else
                {
                    _logger.LogInformation($"Id ({id}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result != null)
            {
                _logger.LogInformation($"Course ({id}) were received");
            }

            return result;
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
            bool result = false;

            try
            {
                if (id > 0)
                {
                    _logger.LogInformation("DeleteAsync() was called");

                    result = await _courseService.Delete(id);
                }
                else
                {
                    _logger.LogInformation($"Id ({id}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result)
            {
                _logger.LogInformation($"Course ({id}) was deleted");
            }

            return result;
        }
    }
}
