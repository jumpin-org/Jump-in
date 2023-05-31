using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateway", Version = "v1" });
});

builder.Configuration.AddJsonFile("Routing/ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddCors(options =>
{
    var webPortalOrigin = builder.Configuration.GetValue<string>("AllowedOrigins:WebPortal") ?? "";
    options.AddPolicy(name: "CorsPolicy",
                      policy =>
                      {
                          policy.WithOrigins(webPortalOrigin)
                                .WithHeaders("Content-Type")
                                .WithMethods("GET");
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

await app.UseOcelot();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
