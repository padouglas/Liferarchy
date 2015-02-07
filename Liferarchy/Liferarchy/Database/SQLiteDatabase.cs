using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SQLite;



namespace Liferarchy.Database
{
    class SQLiteDatabase : SQLDatabase
    {
        private string FileName;
        
        /// <summary>
        /// Default constructor: initialise the database
        /// </summary>
        public SQLiteDatabase()
        {
            CreateDatabaseFileIfNecessary();
        }

        /// <summary>
        /// Get the SQLite version
        /// </summary>
        public override string GetDatabaseVersion()
        {
            SQLiteConnection databaseConnection;
            string connectionString = String.Format("Data Source={0};Version=3;", FileName);
            string version = null;

            using (databaseConnection = new SQLiteConnection(connectionString))
            {
                databaseConnection.Open();

                using (SQLiteCommand command = new SQLiteCommand(databaseConnection))
                {
                    command.CommandText = "SELECT SQLITE_VERSION()";
                    version = Convert.ToString(command.ExecuteScalar());
                }

                databaseConnection.Close();
            }

            return version;
        }

        /// <summary>
        /// If the SQLite database file does not exist, then create it in the
        /// user local application directory.
        /// </summary>
        private void CreateDatabaseFileIfNecessary()
        {
            string userAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Debug.WriteLine(String.Format("User application data folder is: {0}", userAppDataFolder));

            string dirName = userAppDataFolder + "\\" + SystemConstants.ProgramName;
            FileName = dirName + "\\" + SystemConstants.SQLiteDatabaseName;
            Debug.WriteLine(String.Format("Filename is: {0}", FileName));

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            if (!File.Exists(FileName))
            {
                SQLiteConnection.CreateFile(FileName);
            }
        }

     }
}
