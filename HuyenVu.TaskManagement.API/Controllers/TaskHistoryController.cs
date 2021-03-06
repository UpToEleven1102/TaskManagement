using System;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Models;
using HuyenVu.TaskManagement.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace HuyenVu.TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/task-history")]
    public class TaskHistoryController: ControllerBase
    {
        private readonly ITaskHistoryService _taskHistoryService;

        public TaskHistoryController(ITaskHistoryService taskHistoryService)
        {
            _taskHistoryService = taskHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _taskHistoryService.GetTasks();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskHistoryRequestModel taskRequestModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                var res = await _taskHistoryService.AddTask(taskRequestModel);
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskHistoryRequestModel taskRequestModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);

                var res = await _taskHistoryService.UpdateTask(taskRequestModel);
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
                var task = await _taskHistoryService.GetTaskById(id);
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
                var task = await _taskHistoryService.DeleteTask(id);
                return task ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}