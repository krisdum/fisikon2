using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace fiztestone.Services
{
    public class Dapperr : IDapper
    {
        private readonly IConfiguration _config;
        private string ConnectionString = "FizikonDb";

        public Dapperr(IConfiguration config)
        {
            _config = config;
        }
        public void Dispose()
        {
        }
        public List<T> GetList<T>(string query, DynamicParameters? parms, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString));
            return db.Query<T>(query, parms, commandType: commandType).ToList();
        }

       
        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(ConnectionString));
        }

        
    }
}
