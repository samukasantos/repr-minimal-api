namespace Users.Api.Contracts.Responses
{
    public class GetAllUserResponse
    {
        public IEnumerable<UserResponse> Users { get; init; } = Enumerable.Empty<UserResponse>();
    }
}
