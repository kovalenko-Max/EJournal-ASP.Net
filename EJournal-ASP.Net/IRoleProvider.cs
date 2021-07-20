using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EJournal_ASP.Net
{
    public interface IRoleProvider
    {
        Task<ICollection<string>> GetUserRolesAsync(string userName);
    }
}
