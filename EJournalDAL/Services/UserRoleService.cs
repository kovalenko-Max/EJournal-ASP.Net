using AutoMapper;
using DataModels;
using EJournalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly EJournalDB _dbConnection;
        private readonly IMapper _mapper;

        public UserRoleService(IMapper mapper, EJournalDB dbConnection)
        {
            _mapper = mapper;
            _dbConnection = dbConnection;
        }

       public async Task<IEnumerable<UserRole>> GetUserRolesAsync()
        {
            var result = _dbConnection.GetAllUserRoles();
            return _mapper.Map<List<UserRole>>(result);
        }
    }
}
