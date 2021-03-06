using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HuyenVu.TaskManagement.Core.Models;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using HuyenVu.TaskManagement.Core.ServiceInterface;
using HuyenVu.TaskManagement.Infrastructure.Helpers;
using Task = HuyenVu.TaskManagement.Core.Entities.Task;

namespace HuyenVu.TaskManagement.Infrastructure.Services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _requestMapper;
        private readonly IMapper _responseMapper;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _requestMapper = MapperFactory.GetMapper<TaskRequestModel, Task>();
            _responseMapper = MapperFactory.GetMapper<Task, TaskResponseModel>();
        }

        public System.Threading.Tasks.Task<Task> AddTask(TaskRequestModel taskRequest)
        {
            var task = _requestMapper.Map<Task>(taskRequest);
            return _taskRepository.Create(task);
        }

        public System.Threading.Tasks.Task<Task> UpdateTask(TaskRequestModel taskRequest)
        {
            var task = _requestMapper.Map<Task>(taskRequest);
            return _taskRepository.Update(task); 
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasks()
        {
            var tasks = await _taskRepository.GetAll();

            return _responseMapper.Map<IEnumerable<TaskResponseModel>>(tasks);
        }

        public async Task<TaskResponseModel> GetTaskById(int id)
        {
            var task = await _taskRepository.GetById(id);
            return _responseMapper.Map<TaskResponseModel>(task);
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return false;
            return await _taskRepository.Delete(task);
        }
    }
}