using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shelter.Guestbook.Api;
using Shelter.Guestbook.DataAccess;
using Shelter.Guestbook.Domain.Repositories;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
builder.Host.UseSerilog();
builder.Services.AddSingleton(typeof(ILogger), Log.Logger);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(AssembliesHelper.GetAllAssemblies());

builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();

builder.Services.AddDbContext<GuestbookContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(@"Server=database-sql,1433;Database=master;User=sa;Password=Your_password123;"));

MigrationsHelper.ApplyMigrations();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    Log.CloseAndFlush();
}
