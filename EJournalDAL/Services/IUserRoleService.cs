﻿using EJournalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetUserRolesAsync();
    }
}
