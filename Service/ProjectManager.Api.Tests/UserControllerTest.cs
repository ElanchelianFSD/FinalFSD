using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.Api.Controllers;
using ProjectManager.DataContract;
namespace ProjectManager.Api.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        UserController userController;

        /// <summary>
        /// Get the User details
        /// </summary>
        [TestMethod]
        public void GetAllUserDetails_ShouldNotNull()
        {
            //Arrange
            userController = new UserController();

            //Act
            var userList = userController.GetAllUserDetails();

            //Assert
            Assert.IsNotNull(userList);
            Assert.IsTrue(userList.Count > 0);
        }

        /// <summary>
        /// Add User and get success
        /// </summary>
        [TestMethod]
        public void AddUserDetails_Successfully()
        {
            //Arrange
            userController = new UserController();
            UserModel userModel = new UserModel
            {
                First_Name = "test first",
                Last_Name = "Last Name unit",
                Employee_ID = "105",
                Project_ID = 2,
                IsActive = true
            };
            //Act
            int returnVal = userController.InserUserModel(userModel);

            //Assert            
            Assert.IsNotNull(returnVal);
            Assert.AreEqual(1, returnVal);
        }


        /// <summary>
        /// Update User and get success
        /// </summary>
        [TestMethod]
        public void UpdateUserDetails_Successfully()
        {
            //Arrange
            userController = new UserController();
            UserModel userModel = new UserModel
            {
                User_ID=6,
                First_Name = "test first",
                Last_Name = "Updated name",
                Employee_ID = "105",
                Project_ID = 2,
                IsActive = true
            };
            //Act
            int returnVal = userController.UpdateUserModel(userModel);

            //Assert            
            Assert.IsNotNull(returnVal);
            Assert.AreEqual(1, returnVal);
        }
    }
}
