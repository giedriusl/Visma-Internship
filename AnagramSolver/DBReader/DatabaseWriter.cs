using Interfaces;
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
                command.Parameters.Add(new SqlParameter("@TableName",tableName));
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

            listOfWords.ForEach(data => table.Rows.Add(1,data));
            return table;
        }
    }
}
