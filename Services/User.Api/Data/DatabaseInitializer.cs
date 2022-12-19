using Dapper;
using Users.Api.Data.Interfaces;

namespace Users.Api.Data
{
    public class DatabaseInitializer
    {
        #region Fields

        private readonly IDbConnectionFactory connectionFactory;

        #endregion

        #region Constructor

        public DatabaseInitializer(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        #endregion

        #region Methods

        public async Task InitializeAsync() 
        { 
            using var connection = await connectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Users (
                Id CHAR(36) PRIMARY KEY,
                Username TEXT NOT NULL,
                Fullname TEXT NOT NULL,
                Email TEXT NOT NULL,
                DataOfBirth TEXT NOT NULL)");
        }

        #endregion
    }
}
