using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataContract;
using ProjectManager.DataAccess;
namespace ProjectManager.Business
{
    public class UserBusiness : IUserBusiness
    {
        UserDataAccess userDataAccess = null;
        public UserBusiness()
        {
            userDataAccess = new UserDataAccess();
        }

        public List<UserModel> GetUserList()
        {
            return userDataAccess.GetUserList();
        }

        public int InsertUserDetails(UserModel userModel)
        {
            return userDataAccess.InsertUserDetails(userModel);
        }

        public int UpdateUserDetails(UserModel userModel)
        {
            return userDataAccess.UpdateUserDetails(userModel);
        }

        public int DeleteUser(UserModel userModel)
        {
            return userDataAccess.DeleteUserDetails(userModel);
        }
    }
}
