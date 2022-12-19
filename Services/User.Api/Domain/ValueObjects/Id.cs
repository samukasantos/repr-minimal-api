using ValueOf;

namespace Users.Api.Domain.ValueObjects
{
    public class Id : ValueOf<Guid, Id>
    {
        #region Methods

        protected override void Validate()
        {
            if(Value == Guid.Empty) 
            {
                throw new ArgumentException("Id is required", nameof(Id));
            }
        }

        #endregion
    }
}
