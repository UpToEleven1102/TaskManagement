using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Models;
using TaskEntity = HuyenVu.TaskManagement.Core.Entities.Task;

namespace HuyenVu.TaskManagement.Core.ServiceInterface
{
    public interface ITaskService
    {
        public Task<TaskEntity> AddTask(TaskRequestModel task);

        public Task<TaskEntity> UpdateTask(TaskRequestModel task);

        public Task<IEnumerable<TaskResponseModel>> GetTasks();

        public Task<TaskResponseModel> GetTaskById(int id);
        
        public Task<bool> DeleteTask(int id);

        public Task<bool> CompleteTask(int id);
    }
}