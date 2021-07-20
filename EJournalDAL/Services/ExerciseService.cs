using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static DataModels.EJournalDBStoredProcedures;

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
            var exercises = new List<GetExercisesByGroupResult>(_dbConnection.GetExercisesByGroup(groupId));

            List<Exercise> resultExercise = new List<Exercise>();

            int check = -1;

            foreach (var e in exercises)
            {
                if (e.Id != check)
                {
                    resultExercise.Add(new Exercise
                    {
                        Id = e.Id,
                        Description = e.Description,
                        Deadline = e.Deadline,
                        IdGroup = e.IdGroup,
                        ExerciseType = (ExerciseType)Enum.Parse(typeof(ExerciseType), e.ExerciseType),
                        StudentMarks = new List<StudentMark>()
                    });

                    check = e.Id;
                }

            }

            foreach (var re in resultExercise)
            {
                foreach (var e in exercises)
                {
                    if (re.Id == e.IdExercise)
                    {
                        if (e.IdStudent != null)
                        {
                            re.StudentMarks.Add(new StudentMark(e.IdStudent ??= 0, e.Name, e.Surname, e.Point ??= 0));
                        }
                    }
                }
            }

            return resultExercise;
        }

        public async Task<int?> AddExcerciseToGroup(Exercise exercise)
        {
            var dt = GetExerciseModel(exercise);

            return _dbConnection.AddExerciseToStudent(exercise.IdGroup, exercise.Description,
                exercise.ExerciseType.ToString(), exercise.Deadline, dt);
        }

        public async Task<bool> UpdateStudentsExcercise(Exercise exercise)
        {
            var dt = GetExerciseModel(exercise);

            int result = _dbConnection.UpdateStudentExercise(exercise.Id, exercise.IdGroup, exercise.Description,
                exercise.ExerciseType.ToString(), exercise.Deadline, dt);

            return result > 0;
        }

        public async Task<bool> DeleteExcercise(int exerciseId)
        {
            int result = _dbConnection.DeleteStudentExercise(exerciseId);

            return result > 0;
        }

        private DataTable GetExerciseModel (Exercise exercise)
        {
            var exerciseModel = new DataTable();
            exerciseModel.Columns.Add("IdStudent");
            exerciseModel.Columns.Add("IdExercise");
            exerciseModel.Columns.Add("Points");

            foreach (var student in exercise.StudentMarks)
            {
                exerciseModel.Rows.Add(new object[] { student.Student.Id, null, student.Point });
            }

            return exerciseModel;
        }
    }
}
