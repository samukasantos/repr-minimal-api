using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Users.Api.Adapters;
using Users.Api.Contracts.Requests;
using Users.Api.Contracts.Responses;
using Users.Api.Services.Interfaces;

namespace Users.Api.Endpoints
{
    public class GetUserEndpoint : Endpoint<GetUserRequest, UserResponse>
    {
        #region Fields

        private readonly IUserService userService;

        #endregion

        #region Constructor

        public GetUserEndpoint(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region Methods

        public override void Configure()
        {
            Get("users/{id:guid}");
            AllowAnonymous();
            Version(1);
        }

        public override async Task HandleAsync(GetUserRequest req, CancellationToken ct)
        {
            var user = await userService.GetAsync(req.Id);

            if (user is null) 
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var userResponse = user.ToUserResponse();
            await SendOkAsync(userResponse, ct);
        }

        #endregion
    }
}
