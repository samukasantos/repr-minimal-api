﻿namespace Users.Api.Contracts.Requests
{
    public class CreateUserRequest
    {
        #region Properties

        public string Username { get; init; } = default!;
        public string FullName { get; init; } = default!;
        public string Email { get; init; } = default!;
        public DateTime DateOfBirth { get; init; }

        #endregion
    }
}
