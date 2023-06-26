using JumpIn.Authentication.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

builder.Services.AddSingleton<JwtTokenService>();

app.UseAuthorization();

app.MapControllers();

app.Run();
