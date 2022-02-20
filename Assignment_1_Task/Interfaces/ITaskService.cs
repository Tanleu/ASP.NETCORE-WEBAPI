using Assignment_1_Task.Models;

namespace Assignment_1_Task.Interfaces
{
    public interface ITaskService
    {
        public TaskModel Create(TaskModel task);
        public IEnumerable<TaskModel> List();
        public TaskModel Update(TaskModel task);
        public TaskModel Delete(TaskModel task);
    }

    public interface ITaskExtensionService
    {
        public List<TaskModel> BulkCreate(List<TaskModel> tasks);
        public List<TaskModel> BulkDelete(List<TaskModel> tasks);
    }
}