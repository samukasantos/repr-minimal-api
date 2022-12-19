using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class CreateUserSummary : Summary<CreateUserEndpoint>
    {
        #region Constructor

        public CreateUserSummary()
        {
            Summary = "Creates a new user.";
            Description = "Creates a new user.";
            Response<UserResponse>(201, "User was sucessfully created.");
            Response<ValidationFailureResponse>(400, "The request did not pass validation checks.");
        }

        #endregion
    }
}
