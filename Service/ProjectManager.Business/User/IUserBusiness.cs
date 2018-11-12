using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataContract;

namespace ProjectManager.Business
{
    public interface IUserBusiness
    {
        List<UserModel> GetUserList();
        int InsertUserDetails(UserModel userModel);
        int UpdateUserDetails(UserModel userModel);
        int DeleteUser(UserModel userModel);        
    }
}
