﻿using Interfaces;
using System;

namespace DBReader
{
    public class DBUploader
    {
        private readonly IDisplay _display;
        private static int _min;
        private static string _path;
        private static string _connectionString;

        public DBUploader(IDisplay display, int min, string path, string connectionString)
        {
            _display = display;
            _min = min;
            _path = path;
            _connectionString = connectionString;
        }

        public void DbInit()
        {
            DatabaseWriter dbWriter = new DatabaseWriter(_connectionString);
            var fileReader = new FileReader(_display, _path, _min);
            var words = fileReader.ParseText();
            dbWriter.DatabaseInit(words);
            _display.Print("Success");
        }

        public void DeleteTableByName()
        {
            DatabaseWriter dbWriter = new DatabaseWriter(_connectionString);
            _display.Print("Enter table name: ");
            var tableName = Console.ReadLine();
            dbWriter.DeleteTableData(tableName);
            _display.Print("Success");
        }

    }
}
