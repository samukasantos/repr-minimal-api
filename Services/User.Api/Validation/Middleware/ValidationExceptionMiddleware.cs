using FluentValidation;
using Users.Api.Contracts.Responses;

namespace Users.Api.Validation.Middleware
{
    public class ValidationExceptionMiddleware
    {
        #region Fields

        private readonly RequestDelegate request;

        #endregion

        #region Constructor

        public ValidationExceptionMiddleware(RequestDelegate request)
        {
            this.request = request;
        }

        #endregion

        #region Methods

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await request(context);
            }
            catch (ValidationException exception)
            {
                context.Response.StatusCode = 400;
                var messages = exception.Errors.Select(e => e.ErrorMessage).ToList();
                var validationFailtureResponse = new ValidationFailureResponse
                {
                    Errors = messages
                };
                await context.Response.WriteAsJsonAsync(validationFailtureResponse);
            }
        }

        #endregion
    }
}
