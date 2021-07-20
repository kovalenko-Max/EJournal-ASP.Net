using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        public async Task<Group> GetGroupByIdAsync(int id)
        {
            Group result = null;

            try
            {
                if (id > 0)
                {
                    _logger.LogInformation("GetGroupByIdAsync() was called");

                    result = await _groupService.GetGroupById(id);
                }
                else
                {
                    _logger.LogInformation($"Id ({id}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result != null)
            {
                _logger.LogInformation($"Group ({id}) were received");
            }

            return result;
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
            bool result = false;

            try
            {
                if (idGroup > 0)
                {
                    _logger.LogInformation("DeleteAsync() was called");

                    result = await _groupService.DeleteGroup(idGroup);
                }
                else
                {
                    _logger.LogInformation($"Id ({idGroup}) is Invalid");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            if (result)
            {
                _logger.LogInformation($"Group ({idGroup}) was deleted");
            }

            return result;
        }
    }
}
