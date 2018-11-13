using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Api.Controllers;
using ProjectManager.DataContract;
using NBench;

namespace ProjectManager.NBench
{
    public class NBenchTest
    {

        private Counter _objCounter;

        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
            _objCounter = context.GetCounter("ProjectCounter");
        }

        #region Task Manager
        TaskManagerController taskManagerController;
        [PerfBenchmark(Description = "Counter iteration performance test GETPARENTTASK()", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("ProjectCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetParentTask()
        {
            taskManagerController = new TaskManagerController();
            var bytes = new byte[1024];
            var result = taskManagerController.GetParentTask();
            _objCounter.Increment();
        }

        [PerfBenchmark(Description = "Counter iteration performance test for GETALLTASK()", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("ProjectCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetAllTask()
        {
            taskManagerController = new TaskManagerController();
            var bytes = new byte[1024];
            var result = taskManagerController.GetAllTask();
            _objCounter.Increment();
        }

        #endregion


        #region Project Manager

        ProjectController projectController;

        [PerfBenchmark(Description = "Counter iteration performance test GetAllActiveProject()", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("ProjectCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetAllActiveProject()
        {
            projectController = new ProjectController();
            var bytes = new byte[1024];
            var result = projectController.GetAllProjectDetails();
            _objCounter.Increment();
        }

        #endregion


        #region User Manager

        UserController userController;

        [PerfBenchmark(Description = "Counter iteration performance test for GetAllUser()", NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("ProjectCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetAllUser()
        {
            userController = new UserController();
            var bytes = new byte[1024];
            var result = userController.GetAllUserDetails();
            _objCounter.Increment();
        }
        #endregion

        [PerfCleanup]
        public void Clean()
        {
            //Does nothing
        }
    }
}
