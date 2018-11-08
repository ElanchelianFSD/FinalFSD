using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataContract;
namespace ProjectManager.DataAccess
{
    public interface ITaskManagerDataAccess
    {
        List<ParentTaskDetails> GetParentTaskRepository();
        List<TaskModel> GetAllTaskRepository();

        int InsertTaskRepository(TaskModel taskModel);

        int UpdateTaskRepository(TaskModel taskModel);
    }
}
