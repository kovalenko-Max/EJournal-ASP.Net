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
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            _logger.LogInformation("GetAllAsync() was called");

            return await _studentService.GetAllStudents();

        }

        [HttpGet]
        [Route("id")]
        public async Task<IEnumerable<Student>> GetStudentByIdAsync(int idStudent)
        {
            IEnumerable<Student> result = null;

            try
            {
                if (idStudent > 0)
                {
                    _logger.LogInformation("GetStudentByIdAsync() was called");

                    return await _studentService.GetStudentById(idStudent);
                }
                else
                {
                    _logger.LogInformation($"Id ({idStudent}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result != null)
            {
                _logger.LogInformation($"Student by Id ({idStudent}) were received");
            }

            return result;
        }

        [HttpGet]
        [Route("idGroup")]
        public async Task<IEnumerable<Student>> GetStudentsByGroupIdAsync(int idGroup)
        {
            IEnumerable<Student> result = null;
            try
            {
                if (idGroup > 0)
                {
                    _logger.LogInformation("GetStudentsByGroupIdAsync() was called");

                    return await _studentService.GetStudentById(idGroup);
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
                _logger.LogInformation($"Students of group by Id ({idGroup}) were received");
            }

            return result;
        }

        [HttpPost]
        public async Task<int?> AddAsync(Student student)
        {
            _logger.LogInformation("AddAsync() was called");

            return await _studentService.AddStudent(student);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Student student)
        {
            _logger.LogInformation("UpdateAsync() was called");

            return await _studentService.UpdateStudent(student);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int idStudent)
        {
            bool result = false;

            try
            {
                if (idStudent > 0)
                {
                    _logger.LogInformation("DeleteAsync() was called");

                    return await _studentService.DeleteStudent(idStudent);
                }
                else
                {
                    _logger.LogInformation($"Id ({idStudent}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result)
            {
                _logger.LogInformation($"Student ({idStudent}) was deleted");
            }

            return result;
        }
    }
}

