using FluentValidation;
using Users.Api.Contracts.Requests;

namespace Users.Api.Validation
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        #region Constructor

        public CreateUserRequestValidator()
        {
            RuleFor(p => p.FullName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Username).NotEmpty();
            RuleFor(p => p.DateOfBirth).NotEmpty();
        }

        #endregion
    }
}
