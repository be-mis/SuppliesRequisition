using System.Data.Odbc;
using System.Data;
using SuppliesRequisition.Model;

namespace SuppliesRequisition.Data
{
    public class SAPService
    {
        public List<Items>? Items { get; set; }

        public string SAPCompany { get; set; }
        private string database = "";

        private readonly string _connectionString;
        public SAPService(string server, string user, string password, string databaseNBFI, string databaseEPC)
        {
            var driver = Environment.Is64BitProcess ? "HDBODBC" : "HDBODBC32";

            if (SAPCompany == "EPC" || SAPCompany == "AHLC")
            {
                _connectionString = $"DRIVER={{{driver}}};SERVERNODE={server};UID={user};PWD={password};CS={databaseEPC};";
            }

            else
            {
                _connectionString = $"DRIVER={{{driver}}};SERVERNODE={server};UID={user};PWD={password};CS={databaseNBFI};";
            }

        }
        public List<Items> ExecuteQuery(string query)
        {
            var results = new List<Items>();
            try
            {
                using var connection = new OdbcConnection(_connectionString);
                connection.Open();
                using var command = new OdbcCommand(query, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Map the columns to the Items class properties
                    var item = new Items
                    {
                        ItemCode = reader["ItemCode"]?.ToString(),
                        ItemName = reader["ItemName"]?.ToString(),
                        Size = reader["U_ID007"]?.ToString(),
                        ChildColor = reader["U_ID011"]?.ToString(),
                    };
                    results.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database operation failed: {ex.Message}");
            }
            return results;
        }

        public List<string[]> ExecuteStoredProcedure(string storedProcedureName)
        {
            var results = new List<string[]>();
            try
            {
                using var connection = new OdbcConnection(_connectionString);
                connection.Open();
                using var command = new OdbcCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var row = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader.GetValue(i)?.ToString() ?? string.Empty;
                    }
                    results.Add(row);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Stored procedure execution failed: {ex.Message}");
            }
            return results;
        }
    }

}
