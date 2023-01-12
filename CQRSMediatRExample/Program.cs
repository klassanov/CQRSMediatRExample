using System.Reflection;
using CQRSMediatRExample.Behaviors;
using CQRSMediatRExample.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Register all handlers and pre/post-processors in a given assembly
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<FakeDbStore>();

//The <,>  notation means that the pipeline behavior can be used by any generic tpe parameters
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DoNothingBehaviour<,>));
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
