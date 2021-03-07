using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HuyenVu.TaskManagement.Core.RepositoryInterface
{
    public interface IRepository<T>
    {
        public Task<T> Create(T obj);

        public Task<T> Update(T obj);

        public Task<bool> Delete(T obj);

        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null);

        public Task<T> GetById(int id);

        public Task<int> Count();
    }
}