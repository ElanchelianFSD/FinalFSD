using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataContract
{
    public class ProjectModel
    {        
        public int Project_ID { get; set; }
        public string Project { get; set; }
        public int NoOfTasks { get; set; }        
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Priority { get; set; }
        public int CompletedTasks { get; set; }
        public bool Status { get; set; }
        public string Manager_ID{ get; set; }
        public int? Active_Progress { get; set; }

    }
}
