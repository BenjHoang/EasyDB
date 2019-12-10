using System;
using System.Data.SQLite;

namespace EasyDB
{
    public class SQLiteHelper
    {
        private const string CONNECTION_STRING_FOMRAT = "Data Source={0};Version=3;";

        public SQLiteConnection Database { get; private set; } = null;

        /// <summary>
        /// SQLiteHelper constructors
        /// </summary>
        /// <param name="path">Path to SQLite database</param>
        public SQLiteHelper(string path)
        {
            Database = ConnectDatabase(path);
        }

        /// <summary>
        /// Execute non-querry sqlite command string
        /// </summary>
        /// <param name="commandString">command string</param>
        /// <returns>The number of rows inserted/updated affected by it</returns>
        public string ExecuteCommand(string commandString)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(commandString, Database);
                command.ExecuteNonQuery();
                return "Non-Querry Command Executed";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Open Connection to SQLite Database
        /// </summary>
        /// <returns>True for successful/False for unsucessful</returns>
        public bool OpenConnection()
        {
            if (Database != null)
            {
                Database.Open();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Close Connection to SQLite Database
        /// </summary>
        /// <returns>True for successful/False for unsucessful</returns>
        public bool CloseConnection()
        {
            if (Database != null)
            {
                Database.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Create an empty Sqlite database.
        /// Note: existing file will be overwritten
        /// </summary>
        /// <param name="filePath">Sqlite database file path</param>
        public static void CreateDatabase(string filePath)
        {
            SQLiteConnection.CreateFile(filePath);
        }

        /// <summary>
        /// Setup connection string and create SQLiteConnection object
        /// </summary>
        /// <param name="databasePath"></param>
        /// <returns>SQLiteConnection Database</returns>
        static SQLiteConnection ConnectDatabase(string databasePath)
        {
            return new SQLiteConnection(string.Format(CONNECTION_STRING_FOMRAT, databasePath));
        }
    }
}
