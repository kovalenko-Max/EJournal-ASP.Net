using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAll();
    }
}
