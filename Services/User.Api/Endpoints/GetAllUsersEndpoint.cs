using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Users.Api.Adapters;
using Users.Api.Contracts.Responses;
using Users.Api.Services.Interfaces;

namespace Users.Api.Endpoints
{
    public class GetAllUsersEndpoint : EndpointWithoutRequest<GetAllUserResponse>
    {
        #region Fields

        private readonly IUserService userService;
      
        #endregion

        #region Constructor

        public GetAllUsersEndpoint(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region Methods

        public override void Configure()
        {
            Get("users");
            AllowAnonymous();
            Version(1);
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var users = await userService.GetAllAsync();
            var usersResponse = users.ToUsersResponse();
            await SendOkAsync(usersResponse, ct);
        }

        #endregion
    }
}
