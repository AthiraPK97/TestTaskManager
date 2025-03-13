using System;
using Xunit;
using TaskManagementTest.Controllers;
using TaskManagementTest.Models;
using TaskManagementTest.Services;
using ModelTask = TaskManagementTest.Models.TaskModel;

public class TaskServiceTests
{
    private readonly TaskServices _taskService;

    public TaskServiceTests()
    {
        _taskService = new TaskServices();
    }

    [Fact]
    public void GetTaskById_ShouldReturnCorrectTask()
    {
        try
        {
            var task = _taskService.GetTaskById(1);
            Assert.NotNull(task);
            Assert.Equal(1, task.Id); // Fixed the ID
            Assert.Equal("Initial Task", task.Title);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception: {ex.Message}");
        }
    }

    [Fact]
    public void AddTask_ShouldIncreaseTaskCount()
    {
        try
        {
            var newTask = new ModelTask { Id = 2, Title = "New Task", Description = "A new task" };
            _taskService.AddTask(newTask);
            Assert.Equal(2, _taskService.GetTaskCount());
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception: {ex.Message}");
        }
    }

    [Fact]
    public void DeleteTask_ShouldRemoveCorrectTaskAndReduceCount()
    {
        try
        {
            var newTask = new ModelTask { Id = 2, Title = "Task to Delete", Description = "To be deleted" };
            _taskService.AddTask(newTask);
            _taskService.DeleteTask(2);

            Assert.Throws<KeyNotFoundException>(() => _taskService.GetTaskById(2));
            Assert.Equal(1, _taskService.GetTaskCount());
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception: {ex.Message}");
        }
    }

    [Fact]
    public void AddTask_ShouldThrowExceptionForDuplicateId()
    {
        try
        {
            var duplicateTask = new ModelTask { Id = 1, Title = "Duplicate Task" };
            Assert.Throws<InvalidOperationException>(() => _taskService.AddTask(duplicateTask));
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception: {ex.Message}");
        }
    }

    [Fact]
    public void GetTaskById_ShouldThrowExceptionIfTaskNotFound()
    {
        try
        {
            Assert.Throws<KeyNotFoundException>(() => _taskService.GetTaskById(999));
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception: {ex.Message}");
        }
    }
    [Fact]
    public void ExampleTest()
    {
        Assert.True(true);
    }
}
