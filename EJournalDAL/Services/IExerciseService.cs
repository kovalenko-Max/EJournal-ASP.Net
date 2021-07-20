using EJournalDAL.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetExcercisesByGroupId(int groupId);
        Task<int?> AddExcerciseToGroup(Exercise exercise);
        Task<bool> UpdateStudentsExcercise(Exercise exercise);
        Task<bool> DeleteExcercise(int exerciseId);
    }
}
