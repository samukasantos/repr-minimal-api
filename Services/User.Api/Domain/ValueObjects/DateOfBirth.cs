using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace Users.Api.Domain.ValueObjects
{
    public class DateOfBirth : ValueOf<DateOnly, DateOfBirth>
    {
        #region Methods

        protected override void Validate()
        {
            if(Value > DateOnly.FromDateTime(DateTime.Now)) 
            {
                var message = "Date of birth cannot be in the future";
                throw new ValidationException(message, new[]
                {
                    new ValidationFailure(nameof(DateOfBirth), message)
                }); ;
            }
        }

        #endregion
    }
}
