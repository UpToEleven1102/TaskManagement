using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;
using HuyenVu.TaskManagement.Core.RepositoryInterface;

namespace HuyenVu.TaskManagement.Infrastructure.Repositories
{
    public class TaskHistoryRepository: ITaskHistoryRepository
    {
        public Task<TaskHistory> Create(TaskHistory obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskHistory> Update(TaskHistory obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(TaskHistory taskHistory)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TaskHistory>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskHistory> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}