using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using Task = HuyenVu.TaskManagement.Core.Entities.Task;

namespace HuyenVu.TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        public System.Threading.Tasks.Task<Task> Create(Task obj)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<Task> Update(Task obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Task obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Task>> GetAll(Task obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Task> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}