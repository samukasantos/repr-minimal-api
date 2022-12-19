namespace Users.Api.Contracts.Responses
{
    public class UserResponse
    {
        #region Properties

        public Guid Id { get; init; }
        public string Username { get; init; } = default!;
        public string FullName { get; init; } = default!;
        public string Email { get; init; } = default!;
        public DateTime DateOfBirth { get; init; }

        #endregion
    }
}
