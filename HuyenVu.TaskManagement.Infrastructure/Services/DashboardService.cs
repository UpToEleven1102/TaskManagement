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
    public class DashboardService : IDashboardService
    {
        private readonly IMapper _mapper;
        private readonly IMapper _taskMapper;
        private readonly ITaskHistoryRepository _taskHistoryRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public DashboardService(IUserRepository userRepository, ITaskHistoryRepository taskHistoryRepository,
            ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskHistoryRepository = taskHistoryRepository;
            _taskRepository = taskRepository;
            _mapper = MapperFactory.GetMapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserResponseModel>();
                cfg.CreateMap<TaskHistory, TaskHistoryResponseModel>().ForMember(
                    t => t.User,
                    opt => opt.Ignore()
                );
                cfg.CreateMap<Task, TaskResponseModel>().ForMember(
                    t => t.User,
                    opt => opt.Ignore()
                );
            }));
            _taskMapper = MapperFactory.GetMapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserResponseModel>().MaxDepth(1);
                cfg.CreateMap<TaskHistory, TaskHistoryResponseModel>();
                cfg.CreateMap<Task, TaskResponseModel>();
            }));


            
        }

        public async Task<DashboardResponseModel> GetDashboardInfo()
        {
            var topTaskUsers = await _userRepository.GetMostTaskUser();
            var topCompletedUsers = await _userRepository.GetMostCompletedUser();
            var recentTaskHistory = await _taskHistoryRepository.GetRecent();

            var response = new DashboardResponseModel
            {
                UserCount = await _userRepository.Count(),
                TaskCount = await _taskRepository.Count(),
                TaskHistoryCount = await _taskHistoryRepository.Count(),
                TopTaskUsers = _mapper.Map<IEnumerable<UserResponseModel>>(topTaskUsers),
                TopCompletedUsers = _mapper.Map<IEnumerable<UserResponseModel>>(topCompletedUsers),
                RecentTaskHistories = _taskMapper.Map<IEnumerable<TaskHistoryResponseModel>>(recentTaskHistory)
            };

            return response;
        }
    }
}