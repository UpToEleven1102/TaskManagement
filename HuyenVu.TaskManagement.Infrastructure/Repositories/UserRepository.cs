using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;
using HuyenVu.TaskManagement.Core.RepositoryInterface;

namespace HuyenVu.TaskManagement.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        public Task<User> Create(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Update(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}