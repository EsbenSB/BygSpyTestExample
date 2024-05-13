using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BygSpyTestExample.Model
{
    public class Authorization
    {
        public int Id { get; set; }
        public RoleType Role { get; set; }


    }

    public enum RoleType
    {
        Admin,
        Moderator,
        User,
        Guest
    }
}
