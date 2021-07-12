using EJournalDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetExcercisesByGroupId(int groupId);
        Task<int?> AddExcerciseToGroup(Exercise exercise, DataTable dt);
        Task<bool> UpdateStudentsExcercise(Exercise exercise, DataTable dt);
        Task<bool> DeleteExcercise(int exerciseId);
    }
}
