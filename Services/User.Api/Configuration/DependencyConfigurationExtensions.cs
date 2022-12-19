using Users.Api.Data;
using Users.Api.Data.Interfaces;
using Users.Api.Repositories;
using Users.Api.Repositories.Interfaces;
using Users.Api.Services;
using Users.Api.Services.Interfaces;

namespace Users.Api.Configuration
{
    public static class DependencyConfigurationExtensions
    {
        #region Methods
        
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton<IDbConnectionFactory>(_ => new SqliteConnectionFactory(
                configuration.GetValue<string>("Database:ConnectionString")));
            services.AddSingleton<DatabaseInitializer>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
        } 
        
        #endregion
    }
}
