using MediatR;
using Microsoft.EntityFrameworkCore;
using Shelter.Guestbook.Api;
using Shelter.Guestbook.DataAccess;
using Shelter.Guestbook.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(AssembliesHelper.GetAllAssemblies());

builder.Services.AddScoped<IAnimalsRepository, AnimalsRepository>();

builder.Services.AddDbContext<GuestbookContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(@"Server=db;Database=master;User=sa;Password=Your_password123;")); 

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();