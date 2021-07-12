using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
   public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<IEnumerable<Student>> GetStudentById(int studentId);
        Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId);
        Task<int?> AddStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int studentId);
       
    }
}
