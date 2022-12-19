

using Users.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastendpoints();
builder.Services.AddSwagger();
builder.Services.AddHealthCheck(config);
builder.Services.AddDependencies(config);


var app = builder.Build();

app.UseExceptionMiddleware();
app.UseFastendpointsConfiguration();
app.UseLogging(config);
app.UseSwagger();
app.UseHealthCheck();
app.UseDatabaseConfiguration();

app.Run();
