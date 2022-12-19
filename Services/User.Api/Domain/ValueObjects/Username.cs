using ValueOf;

namespace Users.Api.Domain.ValueObjects
{
    public class Username : ValueOf<string, Username>
    {
        #region Methods

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Value)) 
            {
                throw new ArgumentException("Username is required", nameof(Username));
            }
        }

        #endregion
    }
}
