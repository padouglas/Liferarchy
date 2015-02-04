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
        public SQLiteDatabase()
        {
            connect();
        }

        public override void connect()
        {
            // Connect to the SQLite database file

            //string userAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Debug.WriteLine(String.Format("User application data folder is: {0}", userAppDataFolder));

            string programName = "Liferarchy";
            string databaseName = "liferarchy.db";
            string dirName = userAppDataFolder + "\\" + programName;
            string fileName = dirName + "\\" + databaseName;
            Debug.WriteLine(String.Format("Filename is: {0}", fileName));
            if(!Directory.Exists(dirName))
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
