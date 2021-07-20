using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalDAL.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public UserRole()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is UserRole role &&
                   Id == role.Id &&
                   Username == role.Username &&
                   Role == role.Role;
        }
    }
}
