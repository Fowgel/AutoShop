using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Repositorys
{
    public abstract class BaseRepository<T> : IDisposable
    {
        private readonly string _connectionString;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        protected IDbConnection Connection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
