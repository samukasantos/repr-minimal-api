using FastEndpoints;
using FluentValidation.Results;

namespace Users.Api.Configuration.Services
{
    public class LoggingPreProcessor : IGlobalPreProcessor
    {
        #region Methods
        
        public async Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
        {
            var logger = ctx.Resolve<ILogger<LoggingPreProcessor>>();
            
            logger.LogInformation($"Accessed endpoint.: {ctx.Request.Path} - Method.: {ctx.Request.Method.ToUpper()}");

            await Task.CompletedTask;
        } 

        #endregion
    }
}
