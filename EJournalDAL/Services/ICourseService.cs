using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAll();
        Task<IEnumerable<Course>> GetById(int id);
        Task<int?> Add(string name);
        Task<bool> Update(Course course);
        Task<bool> Delete(int id);
    }
}
