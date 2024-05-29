
using Microsoft.OpenApi.Models;
using Restaurants.API.Extensions;
using Restaurants.API.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.AddPresintation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);




var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder =  scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

await seeder.seed();

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
