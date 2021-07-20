using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            IEnumerable<Exercise> result = null;

            try
            {
                if (idGroup > 0)
                {
                    _logger.LogInformation("GetExcercisesByGroupIdAsync() was called");

                    return await _exerciseService.GetExcercisesByGroupId(idGroup);
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
                _logger.LogInformation($"Excercises of group by Id ({idGroup}) were received");
            }

            return result;
        }

        [HttpPost]
        public async Task<int?> AddAsync(Exercise exercise)
        {
            _logger.LogInformation("AddAsync() was called");

            return await _exerciseService.AddExcerciseToGroup(exercise);
        }

        [HttpPut]
        public async Task<bool> UpdateStudentsExcerciseAsync(Exercise exercise)
        {
            _logger.LogInformation("UpdateStudentsExcerciseAsync() was called");

            return await _exerciseService.UpdateStudentsExcercise(exercise);
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

                    return await _exerciseService.DeleteExcercise(id);
                }
                else
                {
                    _logger.LogInformation($"Id ({ id}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result)
            {
                _logger.LogInformation($"Exercise ({id}) was deleted");
            }

            return result;
        }
    }
}
