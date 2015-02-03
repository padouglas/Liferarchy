using System;
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
        public override void connect()
        {
            // Connect to the SQLite database file

            string userAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Debug.WriteLine("User application data folder is: " + userAppDataFolder);

            SQLiteConnection.CreateFile("dummyfornow.db");
        }
    }
}
