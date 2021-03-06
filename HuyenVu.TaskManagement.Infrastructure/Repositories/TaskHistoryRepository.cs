using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using HuyenVu.TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HuyenVu.TaskManagement.Infrastructure.Repositories
{
    public class TaskHistoryRepository: ITaskHistoryRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TaskHistoryRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskHistory> Create(TaskHistory obj)
        {
            await _dbContext.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskHistory> Update(TaskHistory taskHistory)
        {
            _dbContext.Entry(taskHistory).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return taskHistory;
        }

        public async Task<bool> Delete(TaskHistory taskHistory)
        {
            _dbContext.Set<TaskHistory>().Remove(taskHistory);
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<TaskHistory>> GetAll()
        {
            return await _dbContext.TaskHistories.ToListAsync();
        }

        public async Task<TaskHistory> GetById(int id)
        {
            return await _dbContext.TaskHistories.FindAsync(id);
        }
    }
}