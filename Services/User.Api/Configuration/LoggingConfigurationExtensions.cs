using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;
using Users.Api.Configuration.Services;

namespace Users.Api.Configuration
{
    public static class LoggingConfigurationExtensions
    {
        #region Methods

        public static void AddLoggings(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddKissLog(options =>
                {   
                    options.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null) 
                        {
                            return args.DefaultValue;
                        }   

                        var exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });
        }

        public static void UseLogging(this WebApplication app, IConfiguration configuration) 
        {
            app.UseKissLogMiddleware(options => ConfigureKissLog(configuration));
        }

        private static void ConfigureKissLog(IConfiguration configuration)
        {   
            KissLogConfiguration.Listeners.Add(
                new RequestLogsApiListener(new Application(configuration["KissLog.OrganizationId"], configuration["KissLog.ApplicationId"]))
                {
                    ApiUrl = configuration["KissLog.ApiUrl"],
                    Interceptor = new EndpointInterceptor(),
                });
        }


        #endregion
    }
}
