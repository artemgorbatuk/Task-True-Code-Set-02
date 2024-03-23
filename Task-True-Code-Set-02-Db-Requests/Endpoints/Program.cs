using Endpoints.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("Docker") ?? default!;

builder.Services.UseDbContextFactory(connectionString);
builder.Services.UseDepencyInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
