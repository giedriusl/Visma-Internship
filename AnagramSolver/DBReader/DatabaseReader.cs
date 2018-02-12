using System.Collections.Generic;
using System.Data.SqlClient;
using Interfaces;

namespace DBReader
{
    public class DatabaseReader : IWordRepository
    {
        public void CreateCommand(string query)
        {
            var connectionString = Constants.ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public HashSet<string> ParseText()
        {
            return new HashSet<string>();
        }
    }
}
