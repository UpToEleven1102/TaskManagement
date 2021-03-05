using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;

namespace HuyenVu.TaskManagement.Core.ServiceInterface
{
    public interface IUserService
    {
        public Task<User> AddUser(User user);
    }
}