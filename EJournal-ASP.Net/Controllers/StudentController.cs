using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await _studentService.GetAllStudents();
        }
        [HttpGet]
        [Route("Id")]
        public async Task<IEnumerable<Student>> GetStudentById(int studentId)
        {
            return await _studentService.GetStudentById(studentId);
        }
        [HttpGet]
        [Route("groupId")]
        public async Task<IEnumerable<Student>> GetStudentByGroupId(int groupId)
        {
            return await _studentService.GetStudentById(groupId);
        }
        [HttpPost]
        public async Task<int?> AddStudent(Student student)
        {
            return await _studentService.AddStudent(student);
        }
        [HttpPut]
        public async Task<bool> UpdateStudent(Student student)
        {
            return await _studentService.UpdateStudent(student);
        }
        [HttpDelete]
        public async Task<bool> RemoveStudent(int studentId)
        {
            return await _studentService.DeleteStudent(studentId);
        }
    }
}
