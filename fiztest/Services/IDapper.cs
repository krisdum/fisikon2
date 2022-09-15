using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace fiztestone.Services
{
    public interface IDapper : IDisposable
    {
        DbConnection GetDbconnection();
        List<T> GetList<T>(string query, DynamicParameters? parms, CommandType commandType = CommandType.Text);
        
        
    }
}