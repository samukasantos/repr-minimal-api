using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Users.Api.Adapters;
using Users.Api.Contracts.Requests;
using Users.Api.Contracts.Responses;
using Users.Api.Services.Interfaces;

namespace Users.Api.Endpoints
{
    [HttpPost("users"), AllowAnonymous]
    public class CreateUserEndpoint : Endpoint<CreateUserRequest, UserResponse>
    {
        #region Fields

        private readonly IUserService userService;

        #endregion

        #region Constructor

        public CreateUserEndpoint(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region Methods

        public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
        {
            var user = req.ToUser();

            await userService.CreateAsync(user);

            var userResponse = user.ToUserResponse();

            await SendCreatedAtAsync<GetUserEndpoint>(new { Id = user.Id.Value }, userResponse, generateAbsoluteUrl: true, cancellation: ct);
        }
        #endregion
    }
}
