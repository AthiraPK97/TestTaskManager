namespace TaskManagementTest.Services
{
    public class TaskService
    {
        public string GetTaskStatus(int taskId)
        {
            return taskId % 2 == 0 ? "Completed" : "Pending";
        }

        public string AddTask(string taskName)
        {
            return $"Task '{taskName}' added successfully!";
        }
    }
}
