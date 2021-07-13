using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IExerciseService _exerciseService;
        private DataTable _exerciseModel;
        public List<Exercise> Exercises { get; set; }

        public ExerciseController(IExerciseService exerciseService, ILogger<CourseController> logger)
        {
            _exerciseService = exerciseService;
            _logger = logger;
            Exercises = new List<Exercise>();
            _exerciseModel = new DataTable();
            _exerciseModel.Columns.Add("IdStudent");
            _exerciseModel.Columns.Add("IdExercise");
            _exerciseModel.Columns.Add("Points");
        }

        [HttpGet]
        public async Task<IEnumerable<Exercise>> GetExcercisesByGroupIdAsync(int idGroup)
        {
            return await _exerciseService.GetExcercisesByGroupId(idGroup);
        }

        [HttpPost]
        public async Task<int?> AddAsync([FromQuery] Exercise exercise, [FromBody] DataTable dt)
        {
            return await _exerciseService.AddExcerciseToGroup(exercise, dt);
        }

        [HttpPut]
        public async Task<bool> UpdateStudentsExcerciseAsync([FromQuery] Exercise exercise, [FromBody] DataTable dt)
        {
            return await _exerciseService.UpdateStudentsExcercise(exercise, dt);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _exerciseService.DeleteExcercise(id);
        }
    }
}
