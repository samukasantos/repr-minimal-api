using System.Runtime.InteropServices;
using Users.Api.Data;

namespace Users.Api.Configuration
{
    public static class DatabaseConfigurationExtensions
    {
        #region Methods

        public static async void UseDatabaseConfiguration(this WebApplication app) 
        {
            var databaseInitilizer = app.Services.GetRequiredService<DatabaseInitializer>();
            await databaseInitilizer.InitializeAsync();
        }

        #endregion
    }
}
