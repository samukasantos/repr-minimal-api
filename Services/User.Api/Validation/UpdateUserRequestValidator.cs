using FluentValidation;
using Users.Api.Contracts.Requests;

namespace Users.Api.Validation
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        #region Constructor

        public UpdateUserRequestValidator()
        {
            RuleFor(p => p.FullName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Username).NotEmpty();
            RuleFor(p => p.DateOfBirth).NotEmpty();
        }

        #endregion
    }
}
