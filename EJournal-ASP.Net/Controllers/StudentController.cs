using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            return await _studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("id")]
        public async Task<IEnumerable<Student>> GetStudentByIdAsync(int idStudent)
        {
            return await _studentService.GetStudentById(idStudent);
        }

        [HttpGet]
        [Route("idGroup")]
        public async Task<IEnumerable<Student>> GetStudentsByGroupIdAsync(int idGroup)
        {
            return await _studentService.GetStudentById(idGroup);
        }

        [HttpPost]
        public async Task<int?> AddAsync(Student student)
        {
            return await _studentService.AddStudent(student);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Student student)
        {
            return await _studentService.UpdateStudent(student);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int idStudent)
        {
            return await _studentService.DeleteStudent(idStudent);
        }
    }
}
