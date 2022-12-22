using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Users.Api.Configuration.Services;

namespace Users.Api.Configuration
{
    public static class HealthCheckConfigurationExtensions
    {
        #region Methods
        
        public static void AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {   
            services.AddHealthChecks()
                //.AddCheck<SqliteDatabaseHealthChecks>("")
                .AddSqlite(configuration.GetValue<string>("Database:ConnectionString"), name: "UserDatabase");
            
            services
                .AddHealthChecksUI()
                .AddSqliteStorage(configuration.GetValue<string>("HealthcheckDb:ConnectionString"));
        }

        public static void UseHealthCheck(this WebApplication app) 
        {
            app.UseHealthChecks("/healthz", new HealthCheckOptions() 
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            })
            .UseHealthChecksUI(options => 
            {
                options.UIPath = "/healthz-ui";
            });
        }

        #endregion

    }
}
