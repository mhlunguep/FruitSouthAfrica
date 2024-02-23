using System.Data;

namespace FruitSouthAfrica.Repositories
{
    public interface IRepository<T>
    {
        IDbConnection Connection { get; }

        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> UpdateAsync(T entity);
    }
}