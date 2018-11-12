using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataContract;
using ProjectManager.DataAccess.Entity;
using System.Data.Entity;

namespace ProjectManager.DataAccess
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        public List<ProjectModel> GetAllProject()
        {
            List<ProjectModel> projectDetails = null;
            using (ProjectManagerEntities projectEntity = new ProjectManagerEntities())
            {
                projectDetails = (from projectDts in projectEntity.Projects
                                  select new ProjectModel
                                  {
                                      Project_ID = projectDts.Project_ID,
                                      Project = projectDts.Project1,
                                      Start_Date = projectDts.Start_Date,
                                      End_Date = projectDts.End_Date,
                                      Priority = projectDts.Priority,
                                      Status = projectDts.Status,
                                      NoOfTasks = projectDts.Tasks.Where(x => x.Project_ID == projectDts.Project_ID).Count(),
                                      Manager_ID = projectDts.Manager_ID,
                                      CompletedTasks = projectDts.Tasks.Where(x => x.IsActive == false && x.Project_ID == projectDts.Project_ID).Count(),
                                      Active_Progress = (projectDts.Tasks.Where(x => x.IsActive == false && x.Project_ID == projectDts.Project_ID).Count() * 100) / projectDts.Tasks.Where(x => x.Project_ID == projectDts.Project_ID).Count()
                                  }).OrderByDescending(x => x.Project_ID).ToList();
            }
            
            return projectDetails;
        }

        public int InsertProjectDetails(ProjectModel prjModel)
        {
            int returnVal = 0;
            using (ProjectManagerEntities projectEntity = new ProjectManagerEntities())
            {
                Project objProject = new Project();
                objProject.Project1 = prjModel.Project;
                objProject.Start_Date = prjModel.Start_Date;
                objProject.End_Date = prjModel.End_Date;
                objProject.Priority = prjModel.Priority;
                objProject.Manager_ID = prjModel.Manager_ID;
                objProject.Status = true;
                projectEntity.Projects.Add(objProject);
                try
                {
                    returnVal = projectEntity.SaveChanges();
                }
                catch (Exception ex)
                {
                    return returnVal;
                }
            }

            return returnVal;
        }

        public int UpdateProjectDetails(ProjectModel prjModel)
        {
            int returnVal = 0;

            using (ProjectManagerEntities projEntity = new ProjectManagerEntities())
            {
                Project objProject = projEntity.Projects.Where(x => x.Project_ID == prjModel.Project_ID).FirstOrDefault();
                if (objProject != null)
                {
                    objProject.Project1 = prjModel.Project;
                    objProject.Start_Date = prjModel.Start_Date;
                    objProject.End_Date = prjModel.End_Date;
                    objProject.Priority = prjModel.Priority;
                    objProject.Manager_ID = prjModel.Manager_ID;
                    objProject.Status = prjModel.Status;
                    projEntity.Entry(objProject).State = EntityState.Modified;
                    try
                    {
                        projEntity.SaveChanges();
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
