using EasyDB;
using System;
using System.Collections.Generic;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            string DBPath_SQLite = @"C:\Users\BenLaptop\Desktop\test\db.sqlite";
            string createTableCommand = "CREATE TABLE [IF NOT EXISTS] highscores (name TEXT, score INT)";
            string insertTableCommand = "INSERT INTO highscores (name, score) VALUES {0};";

            //create database example
            SQLiteHelper.CreateDatabase(DBPath_SQLite);
            SQLiteHelper sqliteDB = new SQLiteHelper(DBPath_SQLite);

            //open connection to database
            sqliteDB.OpenConnection();

            //create table
            sqliteDB.ExecuteCommand(createTableCommand);

            //insert into table
            //sqliteDB.ExecuteCommand(string.Format(insertTableCommand, values()));

            //close connection to database
            sqliteDB.CloseConnection();
        }
        static public string values()
        {
            List<string> values = new List<string>();
            for (int i = 0; i < 1; i++)
            {
                values.Add("('Me', 9001)");
            }
            return string.Join(", ", values);
        }
        
    }
}
