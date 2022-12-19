using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;

namespace Users.Api.Configuration
{
    public static class LogginConfigurationExtensions
    {
        #region Methods

        public static void AddLogging(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());
            services.AddLogging(logging =>
            {
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
            var organizationId = configuration["KissLog.OrganizationId"];

            KissLogConfiguration.Listeners.Add(new RequestLogsApiListener(new Application(
                configuration["KissLog.OrganizationId"],
                configuration["KissLog.ApplicationId"]) 
            )
            {
                ApiUrl = configuration["KissLog.ApiUrl"]
            });
        }


        #endregion
    }
}
