using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HuyenVu.TaskManagement.Core.Entities;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using HuyenVu.TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HuyenVu.TaskManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public UserRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(User user)
        {
            _dbContext.Set<User>().Remove(user);
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return filter == null
                ? await _dbContext.Users.Include(u => u.TaskHistories).Include(u => u.Tasks).ToListAsync()
                : await _dbContext.Users.Where(filter).Include(u => u.TaskHistories).Include(u => u.Tasks)
                    .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public Task<int> Count()
        {
            return _dbContext.Users.CountAsync();
        }

        public async Task<IEnumerable<User>> GetMostCompletedUser()
        {
            return await _dbContext.Users.OrderByDescending(u => u.TaskHistories.Count()).Include(u => u.TaskHistories)
                .Take(8).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetMostTaskUser()
        {
            return await _dbContext.Users.OrderByDescending(u => u.Tasks.Count()).Include(u => u.Tasks)
                .Take(8).ToListAsync();
        }
    }
}