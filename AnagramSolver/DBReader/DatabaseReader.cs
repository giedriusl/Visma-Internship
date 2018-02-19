using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Interfaces;

namespace DBReader
{
    public class DatabaseReader : IWordRepository
    {
        private static string _connectionString;

        public DatabaseReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        private HashSet<string> ReadWords(string query)
        {
            HashSet<string> words = new HashSet<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT anagram FROM CachedAnagrams AS a " +
                                                    "JOIN CachedWords AS cw ON a.WordId = w.Id " +
                                                    "WHERE cw.Word = @Word", connection);
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

       /* public List<SearchHistory> GetSearchHistory(string ip)
        {
            List<SearchHistory> history = new List<SearchHistory>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(@"
SELECT 
    u.UserIp
    , u.SearchTime
    , w.Word
    , ca.Anagram 
FROM UserLog AS u 
INNER JOIN CachedWords AS cw ON u.CachedWordId = cw.Id
LEFT JOIN CachedAnagrams AS ca ON cw.Id = ca.WordId 
LEFT JOIN Words AS w ON u.WordId = w.Id 
WHERE u.UserIp = @IP
", connection);
                var parameter = new SqlParameter();
                parameter.ParameterName = "@IP";
                parameter.Value = ip;
                command.Parameters.Add(parameter);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var word = default(string);
                    if (!reader.IsDBNull(2))
                        word = reader.GetString(2);

                    history.Add(new SearchHistory(reader.GetString(0), reader.GetInt32(1), word, reader.GetString(3)));
                }
            }
            return history;
        }*/
    }
}
