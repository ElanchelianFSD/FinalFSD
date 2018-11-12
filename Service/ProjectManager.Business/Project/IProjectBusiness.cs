using ProjectManager.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Business
{
    public interface IProjectBusiness
    {
        List<ProjectModel> GetProjectList();
        int InsertProjectDetails(ProjectModel prjModel);
        int UpdateProjectDetails(ProjectModel prjModel);
    }
}
