using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.DataContract;
using ProjectManager.Business;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Api.Controllers
{
    public class UserController : ApiController
    {
        UserBusiness userMgrBusiness;

        [HttpGet]
        [Route("api/ProjectManager/User/GetAll")]
        public List<UserModel> GetAllUserDetails()
        {
            userMgrBusiness = new UserBusiness();
            List<UserModel> result = userMgrBusiness.GetUserList();
            return result;
        }

        [HttpPost]
        [Route("api/ProjectManager/User/Insert")]
        public int InserUserModel(UserModel userModel)
        {
            userMgrBusiness = new UserBusiness();
            int result = userMgrBusiness.InsertUserDetails(userModel);
            return result;
        }

        [HttpPost]
        [Route("api/ProjectManager/User/Update")]
        public int UpdateUserModel(UserModel userModel)
        {
            userMgrBusiness = new UserBusiness();
            int result = userMgrBusiness.UpdateUserDetails(userModel);
            return result;
        }

        [HttpPost]
        [Route("api/ProjectManager/User/Delete")]
        public int DeleteUserModel(UserModel userModel)
        {
            userMgrBusiness = new UserBusiness();
            int result = userMgrBusiness.DeleteUser(userModel);
            return result;
        }
    }
}
