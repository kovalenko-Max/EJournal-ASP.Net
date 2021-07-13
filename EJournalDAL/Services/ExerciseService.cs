using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static DataModels.EJournalDBDBStoredProcedures;

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
            var exercise = new List<GetExercisesByGroupResult>(_dbConnection.GetExercisesByGroup(groupId));

            return _mapper.Map<List<Exercise>>(exercise);
        }

        public async Task<int?> AddExcerciseToGroup(Exercise exercise, DataTable dt)
        {
            return _dbConnection.AddExerciseToStudent(exercise.IdGroup, exercise.Description,
                exercise.ExerciseType.ToString(), exercise.Deadline, dt);
        }

        public async Task<bool> UpdateStudentsExcercise(Exercise exercise, DataTable dt)
        {
            int result = _dbConnection.UpdateStudentExercise(exercise.Id, exercise.IdGroup, exercise.Description,
                exercise.ExerciseType.ToString(), exercise.Deadline, dt);

            return result > 0;
        }

        public async Task<bool> DeleteExcercise(int exerciseId)
        {
            int result = _dbConnection.DeleteStudentExercise(exerciseId);

            return result > 0;
        }
    }
}
