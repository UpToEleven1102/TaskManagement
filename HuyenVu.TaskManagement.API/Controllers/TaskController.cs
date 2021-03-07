using System;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Models;
using HuyenVu.TaskManagement.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace HuyenVu.TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _taskService.GetTasks();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskRequestModel taskRequestModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                var res = await _taskService.AddTask(taskRequestModel);
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskRequestModel taskRequestModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);

                var res = await _taskService.UpdateTask(taskRequestModel);
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            try
            {
                var task = await _taskService.GetTaskById(id);
                return task == null ? NotFound() : Ok(task);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await _taskService.DeleteTask(id);
                return task ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            try
            {
                await _taskService.CompleteTask(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}