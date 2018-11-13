using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.Api.Controllers;
using ProjectManager.DataContract;
namespace ProjectManager.Api.Tests
{
    [TestClass]
    public class TaskManagerControllerTest
    {
        TaskManagerController taskManagerController;

        /// <summary>
        /// Get the parent task details
        /// </summary>
        [TestMethod]
        public void GetPatientTaskDetails_ShouldNotNull()
        {
            //Arrange
            taskManagerController = new TaskManagerController();

            //Act
            var parentTaskList = taskManagerController.GetParentTask();

            //Assert
            Assert.IsNotNull(parentTaskList);
            Assert.IsTrue(parentTaskList.Count > 0);
        }

        /// <summary>
        /// Get the all task details
        /// </summary>
        [TestMethod]
        public void GetAllTaskDetails_ShouldNotNull()
        {
            //Arrange
            taskManagerController = new TaskManagerController();

            //Act
            var taskList = taskManagerController.GetAllTask();

            //Assert
            Assert.IsNotNull(taskList);
            Assert.IsTrue(taskList.Count > 0);
        }

        /// <summary>
        /// Insert task details and get success
        /// </summary>
        [TestMethod]
        public void InsertTaskDetails_Successfully()
        {
            //Arrange
            taskManagerController = new TaskManagerController();
            TaskModel taskModel = new TaskModel
            {
                Parent_ID = 2,
                Task = "This is the Unit test task",
                Start_Date = DateTime.Parse("15-11-2018"),
                End_Date = DateTime.Parse("25-11-2018"),
                Priority = 2,
                IsActive = true,
                Project_ID = 3,
                User_ID = 1
            };
            //Act
            int returnVal = taskManagerController.InsertTaskDetails(taskModel);

            //Assert            
            Assert.IsNotNull(returnVal);
            Assert.AreEqual(1, returnVal);
        }

        /// <summary>
        /// Update task details and get success
        /// </summary>
        [TestMethod]
        public void UpdateTaskDetails_Successfully()
        {
            //Arrange
            taskManagerController = new TaskManagerController();
            TaskModel taskModel = new TaskModel
            {
                Task_ID=5,
                Parent_ID = 2,
                Task = "This is the Unit test Updated task",
                Start_Date = DateTime.Parse("15-11-2018"),
                End_Date = DateTime.Parse("25-11-2018"),
                Priority = 5,
                IsActive = true,
                Project_ID = 2,
                User_ID = 1
            };
            //Act
            int returnVal = taskManagerController.UpdateEndTask(taskModel);

            //Assert            
            Assert.IsNotNull(returnVal);
            Assert.AreEqual(1, returnVal);
        }
    }
}
