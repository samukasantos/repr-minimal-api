using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class GetUserSummary : Summary<GetUserEndpoint>
    {
        #region Constructor

        public GetUserSummary()
        {
            Summary = "Return a single user by id.";
            Description = "Return a single user by id.";
            Response<UserResponse>(200, "Successfully found and returned the user.");
            Response(404, "The customer does not exist.");
        }

        #endregion
    }
}
