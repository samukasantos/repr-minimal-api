using FastEndpoints;
using FastEndpoints.Swagger;
using Users.Api.Contracts.Responses;

namespace Users.Api.Configuration
{
    public static class FastEndointsConfigurationExtensions
    {
        #region Methods

        public static void AddFastendpoints(this IServiceCollection services)
        {
            services.AddFastEndpoints();
        }

        public static void UseFastendpointsConfiguration(this WebApplication app)
        {
            app.UseFastEndpoints(f => 
            {
                f.Errors.ResponseBuilder = (failures, _, statusCode) =>
                {
                    return new ValidationFailureResponse
                    {
                        Errors = failures.Select(m => m.ErrorMessage).ToList()
                    };
                };
            });
        }

        #endregion
    }
}
