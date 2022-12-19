using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
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
            
            services.AddHealthChecksUI(options => 
            {
                //options.AddHealthCheckEndpoint("e1", "")
            })
            .AddSqliteStorage(configuration.GetValue<string>("HealthcheckDb:ConnectionString"));
        }

        public static void UseHealthCheck(this WebApplication app) 
        {
            app.UseHealthChecks("/healthz", new HealthCheckOptions() 
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(options => 
            {
                options.UIPath = "/healthz-ui";
            });
        }

        #endregion

    }
}
