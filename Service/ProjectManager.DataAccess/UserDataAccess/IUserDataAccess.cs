using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataContract;
namespace ProjectManager.DataAccess
{
    public interface IUserDataAccess
    {
        List<UserModel> GetUserList();
        int InsertUserDetails(UserModel taskModel);
        int UpdateUserDetails(UserModel taskModel);
        int DeleteUserDetails(UserModel taskModel);
    }
}
