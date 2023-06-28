using JumpIn.Authentication.API.StartupUtils.DependencyResolvers;
using JumpIn.Common.Utility.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDBContexts(DBConnectionHelper.GetConnectionString());

builder.Services.AddCommandHandlers();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
