using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;

namespace HuyenVu.TaskManagement.Core.RepositoryInterface
{
    public interface IUserRepository
    {
        public Task<User> Create(User user);
    }
}