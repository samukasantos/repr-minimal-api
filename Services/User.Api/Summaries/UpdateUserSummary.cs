using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class UpdateUserSummary : Summary<UpdateUserEndpoint>
    {
        #region Constructor

        public UpdateUserSummary()
        {
            Summary = "Update an existing user.";
            Description = "Update an existing user.";
            Response<UserResponse>(204, "The user was successfully updated.");
            Response<ValidationFailureResponse>(400, "The request did not pass validation checks.");
        }

        #endregion

    }
}
