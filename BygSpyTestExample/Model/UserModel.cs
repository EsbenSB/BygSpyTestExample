using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BygSpyTestExample.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public RoleType Role { get; set; }
    }

}
