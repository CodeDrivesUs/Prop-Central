using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.Repository
{
   public class Repository:IRepository
    {
        private int commandTimeout = 120;
        private ISqlDatabaseManager _sqlDatabaseManager;
        public Repository()
        {
            _sqlDatabaseManager = new SqlDatabaseManager();
        }
        public Repository(ISqlDatabaseManager sqlDatabaseManager)
        {
            _sqlDatabaseManager = sqlDatabaseManager;
        }
        public void ExecuteNonQuery(string query, dynamic param = null, CommandType? commandType = null)
        {
            using (SqlConnection connection = _sqlDatabaseManager.GetSQLConnection())
            {
                SqlMapper.Execute(connection, query, param, null, this.commandTimeout, commandType);
            }
        }

        public IEnumerable<T> Query<T>(string query, dynamic param = null, CommandType? commandType = null)
        {
            using (SqlConnection connection = _sqlDatabaseManager.GetSQLConnection())
            {
                var result = SqlMapper.Query<T>(connection, query, param, null, true, this.commandTimeout, commandType);
                return result;
            }
        }

        public T SelectOne<T>(string query, object param = null, CommandType? commandType = null)
        {
            return Query<T>(query, param, commandType).FirstOrDefault();
        }
        private string ParametersToString(DynamicParameters parameters)
        {
            var result = new StringBuilder();

            if (parameters != null)
            {
                var firstParam = true;
                var parametersLookup = (SqlMapper.IParameterLookup)parameters;
                foreach (var paramName in parameters.ParameterNames)
                {
                    if (!firstParam)
                    {
                        result.Append(", ");
                    }
                    firstParam = false;

                    result.Append('@');
                    result.Append(paramName);
                    result.Append(" = ");
                    try
                    {
                        var value = parametersLookup[paramName];// parameters.Get<dynamic>(paramName);
                        result.Append((value != null) ? value.ToString() : "{null}");
                    }
                    catch
                    {
                        result.Append("unknown");
                    }
                }
            }
            return result.ToString();
        }
    }
}
