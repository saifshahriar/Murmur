using Microsoft.EntityFrameworkCore;
using TwitterClone.Application;
using TwitterClone.Infrastructure;
using TwitterClone.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean architecture layers: each layer registers its own services.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (app.Configuration.GetValue<bool>("Database:ApplyMigrationsOnStartup")) {
	using var scope = app.Services.CreateScope();
	await     scope.ServiceProvider.GetRequiredService<TwitterCloneDbContext>()
	    .Database.MigrateAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
