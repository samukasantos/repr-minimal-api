namespace Users.Api.Configuration
{
    public static class SecretsConfigurationServices
    {
        #region Methods
        
        public static void AddSecrets(this WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }
        } 
        
        #endregion
    }
}
