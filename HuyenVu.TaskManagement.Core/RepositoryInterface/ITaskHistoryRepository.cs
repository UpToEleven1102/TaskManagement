using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;

namespace HuyenVu.TaskManagement.Core.RepositoryInterface
{
    public interface ITaskHistoryRepository: IRepository<TaskHistory>
    {
        public Task<IEnumerable<TaskHistory>> GetRecent();
    }
}