using System;

namespace Assignment_1_Task.Models
{
    public class TaskModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }

        public void Update(TaskModel task)
        {
            Title = task.Title;
            Status = task.Status;
        }
    }
}