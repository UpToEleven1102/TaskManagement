using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;
using HuyenVu.TaskManagement.Core.Models;

namespace HuyenVu.TaskManagement.Core.ServiceInterface
{
    public interface IUserService
    {
        public Task<User> AddUser(UserRequestModel user);

        public Task<UserInfoResponseModel> LoginUserAsync(UserRequestModel user);

        public Task<User> UpdateUser(UserUpdateRequestModel user);

        public Task<IEnumerable<UserResponseModel>> GetAllUsers();

        public Task<UserResponseModel> GetUserById(int id);
        
        public Task<bool> DeleteUser(int id);
        
    }
}