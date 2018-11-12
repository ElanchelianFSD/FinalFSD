using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ProjectManager.DataContract;
using ProjectManager.DataAccess.Entity;

namespace ProjectManager.DataAccess
{
    public class TaskManagerDataAccess : ITaskManagerDataAccess
    {
        /// <summary>
        /// To get the all parent task from database
        /// </summary>
        /// <returns></returns>
        public List<ParentTaskDetails> GetParentTaskRepository()
        {
            List<ParentTaskDetails> parentTaskDetails = null;
            using (ProjectManagerEntities taskManagerEntity = new ProjectManagerEntities())
            {
                parentTaskDetails = (from parentTask in taskManagerEntity.ParentTasks
                                     select new ParentTaskDetails
                                     {
                                         Parent_ID = parentTask.Parent_ID,
                                         Parent_Task = parentTask.Parent_Task
                                     }).ToList();
            }
            return parentTaskDetails;
        }



        public List<TaskModel> GetAllTaskRepository()
        {
            List<TaskModel> taskModel = null;
            using (ProjectManagerEntities taskManagerEntity = new ProjectManagerEntities())
            {
                taskModel = (from taskDts in taskManagerEntity.Tasks.Include("ParentTask")
                             orderby taskDts.Start_Date, taskDts.Task_ID descending
                             select new TaskModel
                             {
                                 Parent_ID = taskDts.ParentTask.Parent_ID,
                                 ParentTask = taskDts.ParentTask.Parent_Task,
                                 Task_ID = taskDts.Task_ID,
                                 Task = taskDts.Task1,
                                 Start_Date = taskDts.Start_Date,
                                 End_Date = taskDts.End_Date,
                                 Priority = taskDts.Priority,
                                 IsActive = taskDts.IsActive,
                                 User_ID = taskDts.User_ID,
                                 Project_ID = taskDts.Project_ID,
                                 Project_Name = taskDts.Project.Project1,
                                 Parent_Task =taskDts.ParentTask.Parent_Task
                             }).ToList();
            }
            return taskModel;
        }

        public int InsertTaskRepository(TaskModel taskModel)
        {
            int returnVal = 0;
            using (ProjectManagerEntities taskManagerEntity = new ProjectManagerEntities())
            {
                Task objtask = new Task();
                objtask.Task1 = taskModel.Task;
                objtask.Parent_ID = taskModel.Parent_ID;
                objtask.Start_Date = taskModel.Start_Date;
                objtask.End_Date = taskModel.End_Date;
                objtask.IsActive = true;
                objtask.Priority = taskModel.Priority;
                objtask.Project_ID = taskModel.Project_ID;
                objtask.User_ID = taskModel.User_ID;
                taskManagerEntity.Tasks.Add(objtask);
                try
                {
                    returnVal = taskManagerEntity.SaveChanges();
                }
                catch (Exception ex)
                {
                    return returnVal;
                }

            }
            return returnVal;
        }

        public int UpdateTaskRepository(TaskModel taskModel)
        {
            int returnVal = 0;
            using (ProjectManagerEntities taskManagerEntity = new ProjectManagerEntities())
            {
                Task objtask = taskManagerEntity.Tasks.Where(x => x.Task_ID == taskModel.Task_ID).FirstOrDefault();
                if (objtask != null)
                {
                    objtask.Task1 = taskModel.Task;
                    objtask.Parent_ID = taskModel.Parent_ID;
                    objtask.Start_Date = taskModel.Start_Date;
                    objtask.End_Date = taskModel.End_Date;
                    objtask.IsActive = taskModel.IsActive;
                    objtask.Priority = taskModel.Priority;
                    objtask.Project_ID = taskModel.Project_ID;
                    objtask.User_ID = taskModel.User_ID;
                    taskManagerEntity.Entry(objtask).State = EntityState.Modified;
                    try
                    {
                        taskManagerEntity.SaveChanges();
                        returnVal = 1;
                    }
                    catch (Exception ex)
                    {
                        return returnVal;
                    }
                }

            }
            return returnVal;
        }
    }
}
