using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace Users.Api.Domain.ValueObjects
{
    public class FullName : ValueOf<string, FullName>
    {
        #region Fields

        private static readonly Regex FullNameRegex = 
            new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion

        #region Methods

        protected override void Validate()
        {
            if (!FullNameRegex.IsMatch(Value)) 
            {
                var message = $"{Value} is not a valid full name";
                throw new ValidationException(message, new[]
                {
                    new ValidationFailure(nameof(FullName), message)
                });
            }
        }

        #endregion
    }
}
