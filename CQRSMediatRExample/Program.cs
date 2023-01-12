using System.Reflection;
using CQRSMediatRExample.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Register all handlers and pre/post-processors in a given assembly
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<FakeDbStore>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
