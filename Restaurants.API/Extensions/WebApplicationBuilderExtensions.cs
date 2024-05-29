﻿using Microsoft.OpenApi.Models;
using Restaurants.API.Middlewares;
using Serilog;
using Serilog.Events;
using System.Runtime.CompilerServices;

namespace Restaurants.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresintation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference{  Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
            },
        []
    }});
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
            .WriteTo.File("Logs/Restaurant.API-.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
            .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}|{NewLine} {Message:lj}{NewLine}{Exception}");
        });
    }
}
