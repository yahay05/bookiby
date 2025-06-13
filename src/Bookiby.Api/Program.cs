using Bookiby.Api.Extensions;
using Bookiby.Application;
using Bookiby.Infrastructure;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    
    app.ApplyMigrations();
    //app.SeedData();
}


app.UseCustomExceptionHandler();

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();