using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HuyenVu.TaskManagement.Core.Entities;
using HuyenVu.TaskManagement.Core.Models;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using HuyenVu.TaskManagement.Core.ServiceInterface;
using HuyenVu.TaskManagement.Infrastructure.Helpers;
using Task = HuyenVu.TaskManagement.Core.Entities.Task;

namespace HuyenVu.TaskManagement.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _requestMapper;
        private readonly IMapper _responseMapper;
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public TaskService(ITaskRepository taskRepository, ITaskHistoryRepository taskHistoryRepository)
        {
            _taskRepository = taskRepository;
            _taskHistoryRepository = taskHistoryRepository;
            _requestMapper = MapperFactory.GetMapper<TaskRequestModel, Task>();
            _responseMapper = MapperFactory.GetMapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskResponseModel>();
                cfg.CreateMap<User, UserResponseModel>().MaxDepth(1);
            }));
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

        public async System.Threading.Tasks.Task<bool> CompleteTask(int id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return false;
            
            var taskHistory = new TaskHistory()
            {
                UserId   = task.UserId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Remarks = task.Remarks,
                Completed = DateTime.Now,
            };
            await _taskHistoryRepository.Create(taskHistory);
            return await DeleteTask(id);
        }
    }
}