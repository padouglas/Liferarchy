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
        private SQLiteConnection dbConnection;
        private string fileName;
        
        /// <summary>
        /// Default constructor: initialise the database
        /// </summary>
        public SQLiteDatabase()
        {
            connect();
        }

        /// <summary>
        /// Connect to the SQLite database file
        /// </summary>
        public override void connect()
        {
            // Create (if needed) and connect to the SQLite database file
            createDatabaseFileIfNecessary();
            string connectionString = String.Format("Data Source={0};Version=3;", fileName);
            dbConnection = new SQLiteConnection(connectionString);          
        }

        /// <summary>
        /// If the SQLite database file does not exist, then create it in the
        /// user local application directory.
        /// </summary>
        private void createDatabaseFileIfNecessary()
        {
            string userAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Debug.WriteLine(String.Format("User application data folder is: {0}", userAppDataFolder));

            string dirName = userAppDataFolder + "\\" + SystemConstants.ProgramName;
            fileName = dirName + "\\" + SystemConstants.SQLiteDatabaseName;
            Debug.WriteLine(String.Format("Filename is: {0}", fileName));

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            if (!File.Exists(fileName))
            {
                SQLiteConnection.CreateFile(fileName);
            }
        }

     }
}
