using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagementTest.Models;

namespace TaskManagementTest.Services
{
    public class TaskServices
    {
        private readonly List<TaskModel> _tasks = new();

        public TaskServices()
        {
            // Seed some tasks
            _tasks.Add(new TaskModel { Id = 1, Title = "Initial Task", Description = "First task", IsCompleted = false });
        }

        // Get task by ID
        public TaskModel GetTaskById(int id)
        {
            try
            {
                var task = _tasks.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    throw new KeyNotFoundException($"Task with ID {id} not found.");
                }
                return task;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTaskById: {ex.Message}");
                throw;
            }
        }

        // Create a new task
        public void AddTask(TaskModel newTask)
        {
            try
            {
                if (_tasks.Any(t => t.Id == newTask.Id))
                {
                    throw new InvalidOperationException($"Task with ID {newTask.Id} already exists.");
                }
                _tasks.Add(newTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddTask: {ex.Message}");
                throw;
            }
        }

        // Delete a task
        public void DeleteTask(int id)
        {
            try
            {
                var task = GetTaskById(id); // Throws if not found
                _tasks.Remove(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteTask: {ex.Message}");
                throw;
            }
        }

        // Get total task count
        public int GetTaskCount()
        {
            try
            {
                return _tasks.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTaskCount: {ex.Message}");
                throw;
            }
        }
    }
}
