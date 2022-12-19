using Users.Api.Contracts.Responses;
using Users.Api.Domain.Entities;

namespace Users.Api.Adapters
{
    public static class ApiContractAdapters
    {
        #region Methods

        public static UserResponse ToUserResponse(this User user) 
        {
            return new UserResponse
            {
                Id = user.Id.Value,
                Email = user.Email.Value,
                Username = user.Username.Value,
                FullName = user.Fullname.Value,
                DateOfBirth = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
            };
        }


        public static GetAllUserResponse ToUsersResponse(this IEnumerable<User> users)
        {
            return new GetAllUserResponse
            {
                Users = users.Select(user => new UserResponse 
                {
                    Id = user.Id.Value,
                    Email = user.Email.Value,
                    Username = user.Username.Value,
                    FullName = user.Fullname.Value,
                    DateOfBirth = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
                })
            };
        }

        #endregion
    }
}
