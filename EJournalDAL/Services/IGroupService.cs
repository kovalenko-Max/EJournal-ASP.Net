using EJournalDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroups();
        Task<IEnumerable<Group>> GetGroupById(int groupId);
        Task<int?> AddGroup(Group group);
        Task<int> AddGroupWithStudents(Group group);
        //Task<bool> AddStudentsInGroup(Group group, List<Student> students);
        Task<bool> UpdateGroup(Group group);
        Task<bool> DeleteGroup(int groupId);
        //Task<bool> DeleteStudentsFromGroup(Group group, List<Student> students);
    }
}