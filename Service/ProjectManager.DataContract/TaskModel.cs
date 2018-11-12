using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectManager.DataContract
{
    public class TaskModel
    {
        [Required(ErrorMessage = "Parent Task is required")]
        public int Parent_ID { get; set; }
        public string ParentTask { get; set; }
        public int? Task_ID { get; set; }

        [Required(ErrorMessage = "Task Name is required")]
        public string Task { get; set; }

        public int? Project_ID { get; set; }

        public int? User_ID { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public string Project_Name { get; set; }
        public string Parent_Task { get; set; }
    }
}
