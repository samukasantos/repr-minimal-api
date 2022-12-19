using Users.Api.Domain.ValueObjects;

namespace Users.Api.Domain.Entities
{
    public class User
    {
        #region Properties

        public Id Id { get; init; } = Id.From(Guid.NewGuid());
        public Username Username { get; init; } = default!;
        public FullName Fullname { get; init; } = default!;
        public EmailAddress Email{ get; init; } = default!;
        public DateOfBirth DateOfBirth { get; init; } = default!;

        #endregion
    }
}
