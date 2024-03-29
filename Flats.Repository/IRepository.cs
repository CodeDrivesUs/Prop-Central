﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.Repository
{
   public  interface IRepository
    {
        void ExecuteNonQuery(string query, dynamic param = null, CommandType? commandType = null);

        IEnumerable<T> Query<T>(string query, dynamic param = null, CommandType? commandType = null);

        T SelectOne<T>(string sqlQuery, object param = null, CommandType? commandType = null);
    }
}
