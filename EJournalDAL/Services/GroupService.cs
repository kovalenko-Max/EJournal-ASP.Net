using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static DataModels.EJournalDBDBStoredProcedures;

namespace EJournalDAL.Services
{
    public class GroupService : IGroupService
    {
        private readonly EJournalDB _dbConnection;
        private readonly IMapper _mapper;

        public GroupService(IMapper mapper, EJournalDB dbConnection)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }

        public async Task<int?> AddGroup(Group group)
        {
            return _dbConnection.AddGroup(group.Name, group.Course.Id).FirstOrDefault().Column1;
        }

        public async Task<int> AddGroupWithStudents(Group group)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdGroup");
            dt.Columns.Add("IdStudents");

            foreach (var s in group.Students)
            {
                dt.Rows.Add(new object[] { null, s.Id });
            }

            return _dbConnection.AddGroupWithStudents(group.Name, group.Course.Id, dt);
        }

        public async Task<bool> UpdateStudentsInGroup(Group group, List<int> idsAddStudents, List<int> idsDeleteStudents)
        {
            DataTable addStudents = new DataTable();
            addStudents.Columns.Add("IdGroup");
            addStudents.Columns.Add("IdStudents");

            foreach (var s in idsAddStudents)
            {
                addStudents.Rows.Add(new object[] { group.Id, s });
            }

            DataTable deleteStudents = new DataTable();
            deleteStudents.Columns.Add("IdGroup");
            deleteStudents.Columns.Add("IdStudents");

            foreach (var s in idsDeleteStudents)
            {
                deleteStudents.Rows.Add(new object[] { group.Id, s });
            }

            int result = _dbConnection.UpdateGroupStudents(group.Id, group.Name, group.Course.Id, addStudents, deleteStudents);

            return result > 0;
        }

        public async Task<bool> DeleteGroup(int groupId)
        {
            int result = _dbConnection.DeleteGroup(groupId);

            return result > 0;
        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            IEnumerable<GetAllGroupsResult> groups = new List<GetAllGroupsResult>(_dbConnection.GetAllGroups());

            return _mapper.Map<IEnumerable<Group>>(groups);
        }

        public async Task<IEnumerable<Group>> GetGroupById(int groupId)
        {
            var idGroup = _dbConnection.GetGroup(groupId);

            return _mapper.Map<IEnumerable<Group>>(idGroup);
        }

        public async Task<bool> UpdateGroup(Group group)
        {
            int result = _dbConnection.UpdateGroup(group.Id, group.Name, group.Course.Id);

            return result > 0;
        }
    }
}
