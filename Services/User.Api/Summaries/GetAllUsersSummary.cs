using FastEndpoints;
using Users.Api.Contracts.Responses;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class GetAllUsersSummary : Summary<GetAllUsersEndpoint>
    {
        #region Constructor

        public GetAllUsersSummary()
        {
            Summary = "Returns all the users.";
            Description = "Returns all the users.";
            Response<GetAllUserResponse>(200, "All users was sucessfully created.");
        }

        #endregion
    }
}
