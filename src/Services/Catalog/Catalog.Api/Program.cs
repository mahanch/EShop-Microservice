using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(option =>
{
	option.Connection(builder.Configuration.GetConnectionString("Database")!);
});

var app = builder.Build();

app.MapCarter();

app.Run();
