using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HuyenVu.TaskManagement.Core.Entities;
using HuyenVu.TaskManagement.Core.Models;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using HuyenVu.TaskManagement.Core.ServiceInterface;
using HuyenVu.TaskManagement.Infrastructure.Helpers;

namespace HuyenVu.TaskManagement.Infrastructure.Services
{
    public class TaskHistoryService : ITaskHistoryService
    {
        private readonly IMapper _requestMapper;
        private readonly IMapper _responseMapper;
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public TaskHistoryService(ITaskHistoryRepository taskHistoryRepository)
        {
            _taskHistoryRepository = taskHistoryRepository;
            _requestMapper = MapperFactory.GetMapper<TaskHistoryRequestModel, TaskHistory>();
            _responseMapper = MapperFactory.GetMapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskHistory, TaskHistoryResponseModel>();
                cfg.CreateMap<User, UserResponseModel>();
            }));
        }

        public async Task<TaskHistory> AddTask(TaskHistoryRequestModel taskRequestModel)
        {
            var task = _requestMapper.Map<TaskHistory>(taskRequestModel);
            return await _taskHistoryRepository.Create(task);
        }

        public Task<TaskHistory> UpdateTask(TaskHistoryRequestModel taskRequestModel)
        {
            var task = _requestMapper.Map<TaskHistory>(taskRequestModel);
            return _taskHistoryRepository.Update(task);
        }

        public async Task<IEnumerable<TaskHistoryResponseModel>> GetTasks()
        {
            var tasks = await _taskHistoryRepository.GetAll();
            return _responseMapper.Map<IEnumerable<TaskHistoryResponseModel>>(tasks);
        }

        public async Task<TaskHistoryResponseModel> GetTaskById(int id)
        {
            var task = await _taskHistoryRepository.GetById(id);
            return _responseMapper.Map<TaskHistoryResponseModel>(task);
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _taskHistoryRepository.GetById(id);
            if (task == null) return false;
            return await _taskHistoryRepository.Delete(task);
        }
    }
}