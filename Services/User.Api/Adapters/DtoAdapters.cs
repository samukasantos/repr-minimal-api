using Users.Api.Contracts.Dto;
using Users.Api.Domain.Entities;

namespace Users.Api.Adapters
{
    public static class DtoAdapters
    {
        #region Methods

        public static UserDto ToDto(this User user) 
        {
            return new UserDto
            {
                Id = user.Id.Value.ToString(),
                Email = user.Email.Value,
                Username = user.Username.Value,
                FullName = user.Fullname.Value,
                DateOfBirth = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
            };
        }

        #endregion
    }
}
