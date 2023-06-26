using JumpIn.Authentication.API.Contexts;
using JumpIn.Authentication.API.Login;
using JumpIn.Authentication.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")));
builder.Services.AddScoped<LoginCommandHandler>();
builder.Services.AddSingleton<JwtProvider>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
