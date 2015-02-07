using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liferarchy.Database
{
    abstract class SQLDatabase
    {
        public abstract string GetDatabaseVersion();

        public abstract void CreateTablesIfNecessary();
    }
}
