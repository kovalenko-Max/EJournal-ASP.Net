using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EJournal_ASP.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService, ILogger<GroupController> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _groupService.GetAllGroups();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Group>> GetGroupByIdAsync(int idGroup)
        {
            return await _groupService.GetGroupById(idGroup);
        }

        [HttpPost]
        public async Task<int?> AddAsync(Group group)
        {
            return await _groupService.AddGroup(group);
        }

        [HttpPost("addWithStudents")]
        public async Task<int?> AddGroupWithStudentsAsync(Group group)
        {
            return await _groupService.AddGroupWithStudents(group);
        }

        [HttpPost("updateStudents")]
        public async Task<bool> UpdateStudentsInGroupAsync([FromBody] Group group,
            [FromQuery] List<int> idsAddStudents, [FromQuery] List<int> idsDeleteStudents)
        {
            return await _groupService.UpdateStudentsInGroup(group, idsAddStudents, idsDeleteStudents);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Group group)
        {
            return await _groupService.UpdateGroup(group);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int idGroup)
        {
            return await _groupService.DeleteGroup(idGroup);
        }
    }
}
