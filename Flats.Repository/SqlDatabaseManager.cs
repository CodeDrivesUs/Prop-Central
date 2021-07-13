using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.Repository
{
    public class SqlDatabaseManager: ISqlDatabaseManager
    {
        public SqlDatabaseManager()
        {

        }
        public SqlConnection GetSQLConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["FlatsDatabaseConnection"].ConnectionString);
        }
    }
}
