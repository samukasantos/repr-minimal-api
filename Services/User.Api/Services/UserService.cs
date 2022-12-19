using FluentValidation;
using FluentValidation.Results;
using Users.Api.Adapters;
using Users.Api.Domain.Entities;
using Users.Api.Repositories.Interfaces;
using Users.Api.Services.Interfaces;

namespace Users.Api.Services
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly IUserRepository userRepository;

        #endregion

        #region Constructor

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        #endregion

        #region Methods

        public async Task<bool> CreateAsync(User user)
        {
            var currentUser = await userRepository.GetAsync(user.Id.Value);
            if(currentUser is not null)
            {
                var message = $"A user with id {user.Id} already exists";
                throw new ValidationException(message, new[]
                {
                    new ValidationFailure(nameof(user), message)
                });
            }

            var userDto = user.ToDto();
            return await userRepository.CreateAsync(userDto);
        }

        public async Task<User?> GetAsync(Guid id)
        {
            var userDto = await userRepository.GetAsync(id);
            return userDto?.ToUser();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var usersDto = await userRepository.GetAllAsync();
            return usersDto.Select(u => u.ToUser());
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var userDto = user.ToDto();
            return await userRepository.UpdateAsync(userDto);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await userRepository.DeleteAsync(id);
        }

        
        #endregion
    }
}
