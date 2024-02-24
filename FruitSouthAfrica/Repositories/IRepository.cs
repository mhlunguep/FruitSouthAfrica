
namespace FruitSouthAfrica.Repositories
{
    public interface IRepository
    {
        Task DeleteData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
        Task<T> GetByID<T, U>(string storedProcedure, U id, string connectionId = "DefaultConnection");
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultConnection");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
        Task UpdateData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
    }
}