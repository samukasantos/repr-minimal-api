
using Dapper;
using Users.Api.Contracts.Dto;
using Users.Api.Data.Interfaces;
using Users.Api.Repositories.Interfaces;

namespace Users.Api.Repositories
{
    public class UserRepository : IUserRepository
    {

        #region Fields

        private readonly IDbConnectionFactory connectionFactory;

        #endregion

        #region Constructor

        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        #endregion

        #region Methods

        public async Task<bool> CreateAsync(UserDto user)
        {
            using var connection = await connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO Users (Id, Username, Fullname, Email, DateOfBirth) 
                VALUES (@Id, @Username, @FullName, @Email, @DateOfBirth)",
                user);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var connection = await connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(@"DELETE FROM Users WHERE Id = @Id",
                new { Id = id.ToString() });

            return result > 0;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            using var connection = await connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<UserDto>("SELECT * FROM Users");
        }

        public async Task<UserDto?> GetAsync(Guid id)
        {
            using var connection = await connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<UserDto>(
                @"SELECT * FROM Users WHERE Id = @Id LIMIT 1", new { Id = id.ToString() });
        }

        public async Task<bool> UpdateAsync(UserDto user)
        {
            using var connection = await connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"UPDATE Users SET Username = @Username, Fullname = @FullName, Email = @Email, DateOfBirth = @DateOfBirth
                WHERE Id = @Id", user);

            return result > 0;
        } 
        
        #endregion
    }
}
