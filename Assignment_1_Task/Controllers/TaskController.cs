using Microsoft.AspNetCore.Mvc;
using Assignment_1_Task.Interfaces;
using Assignment_1_Task.Models;
using System.Net;

namespace Assignment_1_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> Index()
        {
            return _taskService.List().ToList();
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Create(TaskModel task)
        {
            try
            {
                var createdTask = _taskService.Create(task);
                return CreatedAtAction(nameof(Create), createdTask.Id, createdTask);
            }
            catch (Exception except)
            {
                return Problem(except.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<TaskModel>> Put(TaskModel task)
        {
            try
            {
                var createdTask = _taskService.Update(task);
                return createdTask;
            }
            catch (Exception except)
            {
                //Redirect to Exception page
                return Problem(except.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<TaskModel>> Delete(TaskModel task)
        {
            try
            {
                var createdTask = _taskService.Delete(task);
                return createdTask;
            }
            catch (Exception except)
            {
                return Problem(except.Message);
            }
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class TaskExtensionController : ControllerBase
    {
        private ITaskExtensionService _taskExtensionService;
        public TaskExtensionController(ITaskExtensionService taskExtensionService)
        {
            _taskExtensionService = taskExtensionService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<TaskModel>>> BulkCreate(List<TaskModel> tasks)
        {
            try
            {
                return _taskExtensionService.BulkCreate(tasks);
            }
            catch (Exception except)
            {
                return Problem(except.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<TaskModel>>> BulkDelete(List<TaskModel> tasks)
        {
            try
            {
                return _taskExtensionService.BulkDelete(tasks);
            }
            catch (Exception except)
            {
                return Problem(except.Message);
            }
        }
    }
}