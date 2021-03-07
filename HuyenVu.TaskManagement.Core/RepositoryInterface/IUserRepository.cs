using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;

namespace HuyenVu.TaskManagement.Core.RepositoryInterface
{
    public interface IUserRepository: IRepository<User>
    {
        public Task<IEnumerable<User>> GetMostCompletedUser();
        public Task<IEnumerable<User>> GetMostTaskUser();
    }
}