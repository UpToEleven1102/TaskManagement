using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;
using HuyenVu.TaskManagement.Core.Models;

namespace HuyenVu.TaskManagement.Core.ServiceInterface
{
    public interface ITaskHistoryService
    {
        public Task<TaskHistory> AddTask(TaskHistoryRequestModel task);

        public Task<TaskHistory> UpdateTask(TaskHistoryRequestModel task);

        public Task<IEnumerable<TaskHistoryResponseModel>> GetTasks();

        public Task<TaskHistoryResponseModel> GetTaskById(int id);

        public Task<bool> DeleteTask(int id);
    }
}