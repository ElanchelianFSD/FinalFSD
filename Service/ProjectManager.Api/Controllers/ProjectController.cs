using ProjectManager.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Business;
namespace ProjectManager.Api.Controllers
{
    public class ProjectController : ApiController
    {
        ProjectBusiness projectBusiness;

        [HttpGet]
        [Route("api/ProjectManager/Project/GetAll")]
        public List<ProjectModel> GetAllProjectDetails()
        {
            projectBusiness = new ProjectBusiness();
            List<ProjectModel> result = projectBusiness.GetProjectList();

            return result;
        }

        [HttpPost]
        [Route("api/ProjectManager/Project/Insert")]
        public int InserProjectModel(ProjectModel prjModel)
        {
            projectBusiness = new ProjectBusiness();
            int result = projectBusiness.InsertProjectDetails(prjModel);
            return result;
        }
        [HttpPost]
        [Route("api/ProjectManager/Project/Update")]
        public int UpdaterojectModel(ProjectModel prjModel)
        {
            projectBusiness = new ProjectBusiness();
            int result = projectBusiness.UpdateProjectDetails(prjModel);
            return result;
        }

    }
}
