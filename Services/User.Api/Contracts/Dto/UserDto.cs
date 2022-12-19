using Users.Api.Domain.Entities;

namespace Users.Api.Contracts.Dto
{
    public class UserDto
    {
        public string Id { get; init; } = default!;
        public string Username { get; init; } = default!;
        public string FullName { get; init; } = default!;
        public string Email { get; init; } = default!;
        public DateTime DateOfBirth { get; init; }

        internal User ToUser()
        {
            throw new NotImplementedException();
        }
    }
}
