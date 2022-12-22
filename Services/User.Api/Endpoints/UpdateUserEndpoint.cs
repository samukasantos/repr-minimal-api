using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Users.Api.Adapters;
using Users.Api.Contracts.Requests;
using Users.Api.Contracts.Responses;
using Users.Api.Services.Interfaces;

namespace Users.Api.Endpoints
{
    public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UserResponse>
    {
        #region Fields

        private readonly IUserService userService;

        #endregion

        #region Constructor

        public UpdateUserEndpoint(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region Methods

        public override void Configure()
        {
            Put("users/{id:guid}");
            AllowAnonymous();
            Version(1);
        }

        public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
        {
            var existingUser = await userService.GetAsync(req.Id);

            if (existingUser is null) 
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var user = req.ToUser();
            await userService.UpdateAsync(user);

            var userResponse = user.ToUserResponse();
            await SendOkAsync(userResponse, ct);
        }

        #endregion
    }
}
