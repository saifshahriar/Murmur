using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;
using TwitterClone.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repo registration
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ITweetRepository, TweetRepository>();

// Services registration
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ITweetService, TweetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
