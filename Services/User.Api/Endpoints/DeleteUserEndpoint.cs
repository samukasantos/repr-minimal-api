using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Users.Api.Contracts.Requests;
using Users.Api.Services.Interfaces;

namespace Users.Api.Endpoints
{
    //[HttpDelete("users/{id:guid}"), AllowAnonymous]
    public class DeleteUserEndpoint : Endpoint<DeleteUserRequest>
    {
        #region Fields

        private readonly IUserService userService;

        #endregion

        #region Constructor

        public DeleteUserEndpoint(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region Methods

        public override void Configure()
        {
            Delete("users/{id:guid}");
            AllowAnonymous();
            //Version(1);
        }

        public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
        {
            var deleted = await userService.DeleteAsync(req.Id);
            if (!deleted) 
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendNoContentAsync(ct);
        }

        #endregion
    }
}
