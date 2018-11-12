using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataContract;
namespace ProjectManager.DataAccess
{
    public interface IProjectDataAccess
    {
        List<ProjectModel> GetAllProject();
        int InsertProjectDetails(ProjectModel prjModel);
        int UpdateProjectDetails(ProjectModel prjModel);
    }
}
