using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IExerciseService _exerciseService;
        
        private DataTable exerciseModel;
        public List<Exercise> Exercises { get; set; }

        public ExerciseController(IExerciseService exerciseService, ILogger<CourseController> logger)
        {
            _exerciseService = exerciseService;
            _logger = logger;

            Exercises = new List<Exercise>();

            exerciseModel = new DataTable();
            exerciseModel.Columns.Add("IdStudent");
            exerciseModel.Columns.Add("IdExercise");
            exerciseModel.Columns.Add("Points");
        }

        [HttpGet]
        public async Task<IEnumerable<Exercise>> GetAsync(int groupId)
        {
            return await _exerciseService.GetExcercisesByGroupId(groupId);
        }

        [HttpPost]
        public async Task<int?> Add([FromQuery]Exercise exercise, [FromBody]DataTable dt)
        {
            return await _exerciseService.AddExcerciseToGroup(exercise, dt);
        }

        [HttpPut]
        public async Task<bool> Update(Exercise exercise)
        {
            return await _exerciseService.UpdateStudentsExcercise(exercise);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _exerciseService.DeleteExcercise(id);
        }
    }
}
