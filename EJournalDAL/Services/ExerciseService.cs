using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly EJournalDB _dbConnection;
        private readonly IMapper _mapper;

        public ExerciseService(IMapper mapper, EJournalDB dbConnection)
        {
            _mapper = mapper;
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<Exercise>> GetExcercisesByGroupId(int groupId)
        {
            return _dbConnection.GetExercisesByGroup(groupId);
        }

        public async Task<int?> AddExcerciseToGroup(Exercise exercise, DataTable dt)
        {
            return _dbConnection.AddExerciseToStudent(exercise.IdGroup, exercise.Description, exercise.ExerciseType.ToString(), exercise.Deadline, dt);
        }

        public async Task<bool> UpdateStudentsExcercise(Exercise exercise)
        {
            int result = _dbConnection.UpdateExercise(exercise.Id, exercise.Description, exercise.Deadline, exercise.IdGroup);
            return result > 0 ? true : false;
        }
        public async Task<bool> DeleteExcercise(int exerciseId)
        {
            int result = _dbConnection.DeleteExercises(exerciseId);
            return result > 0 ? true : false;
        }
    }
}
