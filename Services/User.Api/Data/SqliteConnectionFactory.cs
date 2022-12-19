using Microsoft.Data.Sqlite;
using System.Data;
using Users.Api.Data.Interfaces;

namespace Users.Api.Data
{
    public class SqliteConnectionFactory : IDbConnectionFactory
    {

        #region Fields

        private readonly string connectionString;

        #endregion

        #region Constructor

        public SqliteConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        #region Methods

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        #endregion
    }
}
