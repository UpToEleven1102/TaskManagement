using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using HuyenVu.TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Task = HuyenVu.TaskManagement.Core.Entities.Task;

namespace HuyenVu.TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TaskRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task<Task> Create(Task task)
        {
            await _dbContext.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async System.Threading.Tasks.Task<Task> Update(Task task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> Delete(Task task)
        {
            _dbContext.Set<Task>().Remove(task);
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<Task>> GetAll()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Task> GetById(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }
    }
}