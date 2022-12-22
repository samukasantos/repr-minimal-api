
using Users.Api.Contracts.Dto;
using Users.Api.Contracts.Requests;
using Users.Api.Domain.Entities;
using Users.Api.Domain.ValueObjects;

namespace Users.Api.Adapters
{
    public static class DomainAdapters
    {
        #region Methods

        public static User ToUser(this CreateUserRequest request)
        {
            return new User
            {
                Id = Id.From(Guid.NewGuid()),
                Email = EmailAddress.From(request.Email),
                Username = Username.From(request.Username),
                Fullname = FullName.From(request.FullName),
                DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
            };
        }

        public static User ToUser(this UpdateUserRequest request)
        {
            return new User
            {
                Id = Id.From(request.Id),
                Email = EmailAddress.From(request.Email),
                Username = Username.From(request.Username),
                Fullname = FullName.From(request.FullName),
                DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
            };
        }

        public static User ToUser(this UserDto userDto)
        {
            return new User
            {
                Id = Id.From(Guid.Parse(userDto.Id)),
                Email = EmailAddress.From(userDto.Email),
                Username = Username.From(userDto.Username),
                Fullname = FullName.From(userDto.FullName),
                DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(userDto.DateOfBirth))
            };
        }

        #endregion
    }
}
