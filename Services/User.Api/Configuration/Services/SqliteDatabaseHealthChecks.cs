using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Users.Api.Configuration.Services
{
    public class SqliteDatabaseHealthChecks : IHealthCheck
    {
        #region Methods
        
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        } 
        
        #endregion
    }
}
