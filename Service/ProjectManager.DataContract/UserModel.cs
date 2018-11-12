using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataContract
{
    public class UserModel
    {
        
        public string Employee_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int User_ID { get; set; }
        public int? Project_ID { get; set; }
        public int? Task_ID { get; set; }
        public bool IsActive { get; set; }
        
    }
}
