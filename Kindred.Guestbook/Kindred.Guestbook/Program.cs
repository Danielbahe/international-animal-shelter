using Kindred.Guestbook.Api;
using Kindred.Guestbook.DataAccess;
using Kindred.Guestbook.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
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

builder.Services.AddScoped<IAnimalRepository, AnimalsRepository>();
builder.Services.AddScoped<IShelterRepository, SheltersRepository>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();

builder.Services.AddAutoMapper(AssembliesHelper.GetAllAssemblies());

builder.Services.AddDbContext<GuestbookContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(@"Server=database-sql,1433;Database=master;User=sa;Password=Your_password123;"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<GuestbookContext>();
    db.Database.Migrate();
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
