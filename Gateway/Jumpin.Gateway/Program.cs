using JumpIn.Gateway.Utilities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

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

builder.Configuration.AddOcelotWithSwaggerSupport((o) => {
    o.Folder = "Routing";
});

builder.Services.ConfigureDownstreamHostForOcelot(builder.Configuration);

builder.Services.AddSwaggerForOcelot(builder.Configuration);

builder.Services.AddOcelot(builder.Configuration);
builder.Configuration.AddOcelot("Routing", builder.Environment);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateway", Version = "v1" });
});

var app = builder.Build();

app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerForOcelotUI(options =>
    {
        options.ReConfigureUpstreamSwaggerJson = OcelotFileConfigurationExtensions.AlterUpstreamSwaggerJson;
    });

    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseAuthorization();

app.UseOcelot().Wait();

app.Run();
