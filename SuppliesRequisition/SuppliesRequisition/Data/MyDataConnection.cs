using Dapper;
using MySqlConnector;

namespace SuppliesRequisition.Data
{
    public class MyDataConnection : IMyDataConnection
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync(); // Open the connection
            var rows = await connection.QueryAsync<T>(sql, parameters);
            return rows.ToList();
        }
        public async Task SaveData<T>(string sql, T parameters, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync(); // Open the connection
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
