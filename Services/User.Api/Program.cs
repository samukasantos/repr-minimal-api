

using Users.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.AddSecrets();
var config = builder.Configuration;

builder.Services.AddLoggings();
builder.Services.AddDependencies(config);
builder.Services.AddFastendpoints();
builder.Services.AddHealthCheck(config);
builder.Services.AddSwagger();

var app = builder.Build();

app.UseLogging(config);
app.UseFastendpointsConfiguration();
app.UseMiddlewares();
app.UseHealthCheck();
app.UseSwagger();
app.UseDatabaseConfiguration();

app.Run();
