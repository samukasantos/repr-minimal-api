using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace Users.Api.Domain.ValueObjects
{
    public class EmailAddress : ValueOf<string, EmailAddress>
    {
        #region Fields

        private static readonly Regex EmailRegex =
            new("^[\\w!#$%&’+/=?{|}~^-]+(?:\\.[\\w!#$%&’*+/=?{|}~^-]+)@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion

        #region Methods

        protected override void Validate()
        {
            if (!EmailRegex.IsMatch(Value)) 
            {
                var message = $"{Value} is not a valid email address";
                throw new ValidationException(message, new[]
                {
                    new ValidationFailure(nameof(EmailAddress), message)
                });
            }
        }

        #endregion
    }
}
