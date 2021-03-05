using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuyenVu.TaskManagement.Core.RepositoryInterface
{
    public interface IRepository<T>
    {
        public Task<T> Create(T obj);

        public Task<T> Update(T obj);

        public Task<bool> Delete(T obj);

        public Task<IEnumerable<T>> GetAll(T obj);

        public Task<T> GetById(int id);
    }
}