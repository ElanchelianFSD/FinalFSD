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
    public class UserDataAccess : IUserDataAccess
    {
        public List<UserModel> GetUserList()
        {
            List<UserModel> userDetails = null;
            using (ProjectManagerEntities userEntity = new ProjectManagerEntities())
            {
                userDetails = (from userDts in userEntity.Users
                               select new UserModel
                               {
                                   First_Name = userDts.First_Name,
                                   Last_Name = userDts.Last_Name,
                                   Employee_ID = userDts.Employee_ID,
                                   User_ID = userDts.User_ID
                               }).ToList();
                return userDetails;
            }
        }
        public int InsertUserDetails(UserModel userModel)
        {
            int returnVal = 0;
            using (ProjectManagerEntities userEntity = new ProjectManagerEntities())
            {
                User objUser = new User();
                objUser.First_Name = userModel.First_Name;
                objUser.Last_Name = userModel.Last_Name;
                objUser.Employee_ID = userModel.Employee_ID;
                //objUser.Project_ID = userModel.ProjectId;
                objUser.IsActive = true;
                userEntity.Users.Add(objUser);
                try
                {
                    returnVal = userEntity.SaveChanges();
                }
                catch (Exception ex)
                {
                    return returnVal;
                }
            }

            return returnVal;
        }
        public int UpdateUserDetails(UserModel userModel)
        {
            int returnVal = 0;

            using (ProjectManagerEntities userEntity = new ProjectManagerEntities())
            {
                User objUser = userEntity.Users.Where(x => x.User_ID == userModel.User_ID).FirstOrDefault();
                if (objUser != null)
                {
                    objUser.First_Name = userModel.First_Name;
                    objUser.Last_Name = userModel.Last_Name;
                    objUser.Employee_ID = userModel.Employee_ID;
                    //objUser.Project_ID = userModel.ProjectId;
                    objUser.IsActive = true;
                    userEntity.Entry(objUser).State = EntityState.Modified;
                    try
                    {
                        userEntity.SaveChanges();
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
        public int DeleteUserDetails(UserModel userModel)
        {
            int returnVal = 0;
            using (ProjectManagerEntities userEntity = new ProjectManagerEntities())
            {
                User objUser = userEntity.Users.Where(x => x.User_ID == userModel.User_ID).FirstOrDefault();
                if (objUser != null)
                {
                    objUser.First_Name = userModel.First_Name;
                    objUser.Last_Name = userModel.Last_Name;
                    objUser.Employee_ID = userModel.Employee_ID;
                    //objUser.Project_ID = userModel.ProjectId;
                    objUser.IsActive = false;
                    userEntity.Entry(objUser).State = EntityState.Modified;
                    try
                    {
                        userEntity.SaveChanges();
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