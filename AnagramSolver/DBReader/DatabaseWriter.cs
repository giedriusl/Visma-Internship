using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DBReader
{
    public class DatabaseWriter : IDatabaseWriter
    {
        private static string _connectionString;

        public DatabaseWriter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DeleteTableData(string tableName)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteTableByName";
                command.Parameters.Add(new SqlParameter("@TableName", tableName));
                command.ExecuteNonQuery();
            }
        }



        public void DatabaseInit(HashSet<string> words)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlBulkCopy = new SqlBulkCopy(sqlConnection)
            {
                DestinationTableName = "Words",
                BulkCopyTimeout = 6000
            };
            var dataTable = GetDataTableForWords(words);
            sqlConnection.Open();
            sqlBulkCopy.WriteToServer(dataTable);
            sqlBulkCopy.Close();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private DataTable GetDataTableForWords(HashSet<string> words)
        {
            var listOfWords = words.ToList();
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Word", typeof(string));

            listOfWords.ForEach(data => table.Rows.Add(1, data));
            return table;
        }

        public void WriteCachedWord(string word, List<string> anagrams)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO CachedWords VALUES(@Word)", connection);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Word";
                parameter.Value = word;
                command.Parameters.Add(parameter);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO CachedAnagrams VALUES((SELECT id FROM CachedWords WHERE word = @Word), @Anagram)";
                foreach (var anagram in anagrams)
                {
                    SqlParameter anagramParameter = new SqlParameter();
                    anagramParameter.ParameterName = "@Anagram";
                    anagramParameter.Value = anagram;
                    command.Parameters.Add(anagramParameter);
                    command.ExecuteNonQuery();
                    command.Parameters.Remove(anagramParameter);
                }
            }
        }

        public void SaveUserSearch(string ip, long time, string sortedWord, string originalWord)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO UserLog VALUES(@IP,(SELECT id FROM CachedWords WHERE word = @SWord),(SELECT id FROM Words WHERE word = @OWord), @Time)", connection);
                var ipParameter = new SqlParameter("@IP", ip);
                var timeParameter = new SqlParameter("@Time", time);
                var swordParameter = new SqlParameter("@SWord", sortedWord);
                var owordParameter = new SqlParameter("@OWord", originalWord);
                command.Parameters.Add(ipParameter);
                command.Parameters.Add(timeParameter);
                command.Parameters.Add(swordParameter);
                command.Parameters.Add(owordParameter);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
