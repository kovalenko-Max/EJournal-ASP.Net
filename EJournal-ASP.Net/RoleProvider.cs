using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EJournalDAL.Models;
using EJournalDAL.Services;
using Microsoft.Extensions.Logging;

namespace EJournal_ASP.Net
{
    public class RoleProvider : IRoleProvider
    {
        private readonly ILogger<RoleProvider> _logger;
        private readonly IUserRoleService _userRoleService;
        private IEnumerable<UserRole> _userRoles;

        public RoleProvider(IUserRoleService userRoleService, ILogger<RoleProvider> logger)
        {
            _userRoleService = userRoleService;
            _logger = logger;
            _userRoles = new List<UserRole>();

        }
        public Task<ICollection<string>> GetUserRolesAsync(string userName)
        {
            _userRoles = _userRoleService.GetUserRolesAsync().Result;
            ICollection<string> result = new List<string>();

            if (!string.IsNullOrEmpty(userName))
            {
                foreach (var userRole in _userRoles)
                {
                    if (userName.EndsWith(userRole.Username, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(userRole.Role);
                    }
                }
            }
            return Task.FromResult(result);
        }
    }
}
