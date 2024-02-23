using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FruitSouthAfrica.Repositories
{
    public class Repository<T>
    {
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return await dbConnection.QueryAsync<T>("YourStoredProcedureName", commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            var parameters = new { Id = id };
            return await dbConnection.QueryFirstOrDefaultAsync<T>("YourStoredProcedureName", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(T entity)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            var parameters = new DynamicParameters(entity);
            return await dbConnection.ExecuteAsync("YourStoredProcedureName", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            var parameters = new DynamicParameters(entity);
            return await dbConnection.ExecuteAsync("YourStoredProcedureName", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            var parameters = new { Id = id };
            return await dbConnection.ExecuteAsync("YourStoredProcedureName", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
