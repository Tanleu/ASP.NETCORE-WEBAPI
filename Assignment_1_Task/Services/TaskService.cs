using Assignment_1_Task.Interfaces;
using Assignment_1_Task.Models;
using Assignment_1_Task.DataContexts;

namespace Assignment_1_Task.Services
{
    public class TaskService : ITaskService, ITaskExtensionService
    {
        private List<TaskModel> Tasks = DataContext.GetDataContext().Tasks;
        public List<TaskModel> BulkCreate(List<TaskModel> toCreateTasks)
        {
            try
            {
                toCreateTasks.ForEach(x=> this.Create(x));
            }
            catch(Exception except)
            {
                throw except;
            }
            return toCreateTasks;
        }
        public List<TaskModel> BulkDelete(List<TaskModel> toDeleteTasks)
        {
            try
            {
                toDeleteTasks.ForEach(x => this.Delete(x));
            }
            catch(Exception except)
            {
                throw except;
            }
            return toDeleteTasks;
        }
        public TaskModel Create(TaskModel task)
        {
            try
            {
                var latestCreatedTask = Tasks.OrderByDescending(x=> x.Id).FirstOrDefault();
                task.Id = ( Int32.Parse(latestCreatedTask?.Id ?? "0") + 1).ToString();
                Tasks.Add(task);
            }
            catch(Exception except)
            {
                throw except;
            }
            return task;
        }
        public TaskModel Delete(TaskModel task)
        {
            try
            {
                var toDeleteTask = Tasks.FirstOrDefault(x=> x.Id == task.Id);
                if(toDeleteTask is null) throw new Exception($"Couldn't find this task {task.Id} - {task.Title}");
                Tasks.Remove(toDeleteTask);
                return toDeleteTask;
            }
            catch(Exception except)
            {
                throw except;
            }
        }
        public IEnumerable<TaskModel> List()
        {
            return Tasks;
        }
        public TaskModel Update(TaskModel task)
        {
           try
           {
               var toUpdateTask =  Tasks.FirstOrDefault(x => x.Id == task.Id);
               if(toUpdateTask is null) throw new Exception("This task doesn't exist or someone deleted it");

               toUpdateTask.Update(task);
           }
           catch(Exception except)
           {
               throw except;
           }
           return task;
        }
    }
}