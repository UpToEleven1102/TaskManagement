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
    public class UserService : IUserService
    {
        private readonly IMapper _requestMapper;
        private readonly IMapper _responseMapper;
        private readonly IJwtService _jwtService;

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _requestMapper = MapperFactory.GetMapper<UserRequestModel, User>();
            // kinda hairy, need better mapper
            _responseMapper = MapperFactory.GetMapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserResponseModel>();
                cfg.CreateMap<User, UserInfoResponseModel>();
                cfg.CreateMap<Task, TaskResponseModel>().ForMember(
                    t => t.User,
                    opt => opt.Ignore()
                );
                cfg.CreateMap<TaskHistory, TaskHistoryResponseModel>().ForMember(
                    t => t.User,
                    opt => opt.Ignore()
                );
            }));
        }

        public Task<User> AddUser(UserRequestModel userRequestModel)
        {
            var user = _requestMapper.Map<User>(userRequestModel);
            return _userRepository.Create(user);
        }

        public async Task<UserInfoResponseModel> LoginUserAsync(UserRequestModel user)
        {
            var userDb = await _userRepository.GetUserByEmail(user.Email);
            if (userDb == null || userDb.Password != user.Password) return null;

            var userRes =  _responseMapper.Map<UserInfoResponseModel>(userDb);
            userRes.Token = _jwtService.GenerateJwtToken(userRes);
            return userRes;
        }

        public async Task<User> UpdateUser(UserUpdateRequestModel userRequestModel)
        {
            var user = await _userRepository.GetById(userRequestModel.Id);
            user.Email = userRequestModel.Email;
            user.FullName = userRequestModel.FullName;
            user.MobileNo = userRequestModel.MobileNo;
            if (userRequestModel.Password != null) user.Password = userRequestModel.Password;
            return await _userRepository.Update(user);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            return _responseMapper.Map<IEnumerable<UserResponseModel>>(users);
        }

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            return _responseMapper.Map<UserResponseModel>(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) return false;
            return await _userRepository.Delete(user);
        }
    }
}