using Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DBReader
{
    public class DatabaseWriter : IDatabaseWriter
    {
        public void DatabaseInit(HashSet<string> words)
        {
            var connectionString = "Data Source=LT-LIT-SC-0015;Initial Catalog=AnagramsDB;Integrated Security=True";//Constants.ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);
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
