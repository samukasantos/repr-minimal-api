using FastEndpoints;
using Users.Api.Endpoints;

namespace Users.Api.Summaries
{
    public class DeleteUserSummary : Summary<DeleteUserEndpoint>
    {
        #region Constructor

        public DeleteUserSummary()
        {
            Summary = "Delete an user.";
            Description = "Delete an user.";
            Response(204, "The user was deleted successfully");
            Response(404, "The user was not found.");
        }

        #endregion
    }
}
