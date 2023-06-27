using JumpIn.Authentication.API.StartupUtils.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDBContexts(Environment.GetEnvironmentVariable("DB_CONNECTION"));

builder.Services.AddCommandHandlers();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
