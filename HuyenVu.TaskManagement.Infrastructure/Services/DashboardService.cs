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
    public class DashboardService : IDashboardService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskHistoryRepository _taskHistoryRepository;
        private readonly IMapper _mapper;

        public DashboardService(IUserRepository userRepository, ITaskHistoryRepository taskHistoryRepository, ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskHistoryRepository = taskHistoryRepository;
            _taskRepository = taskRepository;
            _mapper = MapperFactory.GetMapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserResponseModel>();
                cfg.CreateMap<TaskHistory, TaskHistoryResponseModel>();
            }));
        }

        public async Task<DashboardResponseModel> GetDashboardInfo()
        {
            var topUsers = await _userRepository.GetMostTaskUser();
            var recentTaskHistory = await _taskHistoryRepository.GetRecent();
            
            var response = new DashboardResponseModel
            {
                UserCount = await _userRepository.Count(),
                TaskCount = await _taskRepository.Count(),
                TaskHistoryCount = await _taskRepository.Count(),
                Users = _mapper.Map<IEnumerable<UserResponseModel>>(topUsers),
                RecentTaskHistories = _mapper.Map<IEnumerable<TaskHistoryResponseModel>>(recentTaskHistory),
            };

            return response;
        }
    }
}