
using Users.Api.Validation.Middleware;

namespace Users.Api.Configuration
{
    public static class MiddlewareConfigurationExtensions
    {
        #region Methods

        public static void UseMiddlewares(this WebApplication app) 
        {
            app.UseMiddleware<ValidationExceptionMiddleware>();

        }

        #endregion
    }
}
