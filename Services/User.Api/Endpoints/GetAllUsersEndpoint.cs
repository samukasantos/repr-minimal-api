using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Users.Api.Adapters;
using Users.Api.Contracts.Responses;
using Users.Api.Services.Interfaces;

namespace Users.Api.Endpoints
{
    [HttpGet("users"), AllowAnonymous]
    public class GetAllUsersEndpoint : EndpointWithoutRequest<GetAllUserResponse>
    {
        #region Fields

        private readonly IUserService userService;
        private readonly ILogger<GetAllUsersEndpoint> logger;

        #endregion

        #region Constructor

        public GetAllUsersEndpoint(IUserService userService, ILogger<GetAllUsersEndpoint> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public override async Task HandleAsync(CancellationToken ct)
        {
            logger.LogInformation("GetAllUsers - Endpoint");
            var users = await userService.GetAllAsync();
            var usersResponse = users.ToUsersResponse();
            await SendOkAsync(usersResponse, ct);
        }

        #endregion
    }
}
