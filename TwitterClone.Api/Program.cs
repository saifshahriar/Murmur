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
builder.Services.AddSingleton<IBookmarkRepository, BookmarkRepository>();
builder.Services.AddSingleton<IFollowRepository, FollowRepository>();
builder.Services.AddSingleton<ILikeRepository, LikeRepository>();
builder.Services.AddSingleton<IMessageRepository, MessageRepository>();

// Services registration
builder.Services.AddSingleton<IBookmarkService, BookmarkService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ITweetService, TweetService>();
builder.Services.AddSingleton<IFollowService, FollowService>();
builder.Services.AddSingleton<ILikeService, LikeService>();
builder.Services.AddSingleton<IMessageService, MessageService>();

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
