using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Interfaces;

namespace DBReader
{
    public class DatabaseReader : IWordRepository
    {
        private static string ConnectionString;

        public DatabaseReader(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private HashSet<string> ReadWords(string query)
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

        public List<string> GetCachedAnagrams(string word)
        {
            HashSet<string> anagrams = new HashSet<string>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT anagram FROM CachedWord WHERE searchedWord = @Word", connection);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Word";
                parameter.Value = word;
                command.Parameters.Add(parameter);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    anagrams.Add(reader.GetString(0));
                }
            }
            return anagrams.ToList();
        }
    }
}
