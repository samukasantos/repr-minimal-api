using FastEndpoints;
using FastEndpoints.Swagger;
using Users.Api.Validation.Middleware;

namespace Users.Api.Configuration
{
    public static class SwaggerConfigurationExtensions
    {
        #region Methods

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDoc(options => 
            {
                options.DocumentName = "Initial Release";
                options.Title = "Users.Api";
                options.Version = "v1.0";
            }, 
            maxEndpointVersion: 1);
        }

        public static void UseSwagger(this WebApplication app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3(s => s.ConfigureDefaults());
        }

        #endregion
    }
}
