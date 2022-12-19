using System.Data;

namespace Users.Api.Data.Interfaces
{
    public interface IDbConnectionFactory
    {
        public Task<IDbConnection> CreateConnectionAsync();
    }
}
