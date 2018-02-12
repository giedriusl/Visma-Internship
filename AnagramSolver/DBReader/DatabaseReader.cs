using System.Collections.Generic;
using System.Data.SqlClient;
using Interfaces;

namespace DBReader
{
    public class DatabaseReader : IWordRepository
    {
        public static string ConnectionString;

        public DatabaseReader(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public HashSet<string> ReadWords(string query)
        {
            HashSet<string> words = new HashSet<string>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    words.Add(reader.GetString(0));
                }
            }
            return words;
        }

        public HashSet<string> FilterByWord(string filter)
        {
            HashSet<string> words = new HashSet<string>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT word FROM Words WHERE word LIKE '%'+@Filter+'%'", connection);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Filter";
                parameter.Value = filter;
                command.Parameters.Add(parameter);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    words.Add(reader.GetString(0));
                }
            }
            return words;
        }

        public HashSet<string> ParseText()
        {
            var query = "SELECT word FROM Words";
            return ReadWords(query);
        }
    }
}
