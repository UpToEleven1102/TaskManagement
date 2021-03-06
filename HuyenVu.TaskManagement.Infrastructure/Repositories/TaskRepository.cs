using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using Task = HuyenVu.TaskManagement.Core.Entities.Task;

namespace HuyenVu.TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public System.Threading.Tasks.Task<Task> Create(Task obj)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Task> Update(Task obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Task task)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Task> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}