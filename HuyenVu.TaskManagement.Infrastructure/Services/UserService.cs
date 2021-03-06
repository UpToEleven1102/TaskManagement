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
    public class UserService : IUserService
    {
        private readonly IMapper _requestMapper;
        private readonly IMapper _responseMapper;

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _responseMapper = MapperFactory.GetMapper<User, UserResponseModel>();
            _requestMapper = MapperFactory.GetMapper<UserRequestModel, User>();
        }

        public Task<User> AddUser(UserRequestModel userRequestModel)
        {
            var user = _requestMapper.Map<User>(userRequestModel);
            return _userRepository.Create(user);
        }

        public Task<User> UpdateUser(UserRequestModel userRequestModel)
        {
            var user = _requestMapper.Map<User>(userRequestModel);
            return _userRepository.Update(user);
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