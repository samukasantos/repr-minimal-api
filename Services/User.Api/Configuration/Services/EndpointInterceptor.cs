using KissLog;

namespace Users.Api.Configuration.Services
{
    public class EndpointInterceptor : ILogListenerInterceptor
    {
        #region Methods

        public bool ShouldLog(FlushLogArgs args, ILogListener listener)
        {
            if (args.HttpProperties.Request.Url.LocalPath.Contains("/healthz") ||
               args.HttpProperties.Request.Url.LocalPath.Contains("/healthchecks-api") ||
               args.HttpProperties.Request.Url.LocalPath.Contains("/swagger"))
            {
                return false;
            }

            return true;
        }

        public bool ShouldLog(KissLog.Http.HttpRequest httpRequest, ILogListener listener)
        {
            return true;
        }

        public bool ShouldLog(LogMessage message, ILogListener listener)
        {
            return true;
        }

        #endregion
    }
}
