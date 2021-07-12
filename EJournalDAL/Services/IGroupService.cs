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
        Task<bool> UpdateStudentsInGroup(Group group, List<int> idsAddStudents, List<int> idsDeleteStudents);
        Task<bool> UpdateGroup(Group group);
        Task<bool> DeleteGroup(int groupId);
    }
}