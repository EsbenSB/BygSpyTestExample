using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BygSpyTestExample.Model
{
    public class BygSpyContentModel
    {
        public int Id { get; set; }
        public string projectName { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public DateTime dateIsChecked { get; set; }
    }
}
