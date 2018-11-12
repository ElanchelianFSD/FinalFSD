using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataContract;
using ProjectManager.DataAccess;
namespace ProjectManager.Business
{
    public class ProjectBusiness : IProjectBusiness
    {
        ProjectDataAccess projectDataAccess = null;
        public ProjectBusiness()
        {
            projectDataAccess = new ProjectDataAccess();
        }
        public List<ProjectModel> GetProjectList()
        {
            return projectDataAccess.GetAllProject();
        }

        public int InsertProjectDetails(ProjectModel prjModel)
        {
            return projectDataAccess.InsertProjectDetails(prjModel);
        }

        public int UpdateProjectDetails(ProjectModel prjModel)
        {
            return projectDataAccess.UpdateProjectDetails(prjModel);
        }
    }
}
