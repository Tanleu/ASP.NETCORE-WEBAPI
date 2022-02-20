using Assignment_1_Task.Models;

namespace Assignment_1_Task.DataContexts
{
    public class DataContext
    {
        private static DataContext _dataContext;
        public List<TaskModel> Tasks;
        public static DataContext GetDataContext()
        {
            if(_dataContext is null) _dataContext = new DataContext();
            return _dataContext;
        }

        public DataContext()
        {
            Tasks = new List<TaskModel>()
            {
                new TaskModel()
                {
                    Id = "1",
                    Title = "Task 1",
                    Status = true,
                },

                new TaskModel()
                {
                    Id = "2",
                    Title = "Task 2",
                    Status = true,
                },

                new TaskModel()
                {
                    Id = "3",
                    Title = "Task 3",
                    Status = false,
                },

                new TaskModel()
                {
                    Id = "4",
                    Title = "Task 4",
                    Status = true,
                },
            };
        }
    }
}