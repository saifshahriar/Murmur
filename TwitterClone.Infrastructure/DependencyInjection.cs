using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitterClone.Application.Interfaces;
using TwitterClone.Infrastructure.Persistence;
using TwitterClone.Infrastructure.Repositories;

namespace TwitterClone.Infrastructure;

public static class DependencyInjection {
	public static IServiceCollection
	AddInfrastructure(this IServiceCollection services,
	                  IConfiguration          configuration) {
		var connectionString =
		    configuration.GetConnectionString("DefaultConnection")
		    ?? throw new Exception("Database connection "
		                           + "string is not found.");

		services.AddDbContext<TwitterCloneDbContext>(
		    options => options.UseNpgsql(connectionString));

		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<ITweetRepository, TweetRepository>();
		services.AddScoped<IBookmarkRepository, BookmarkRepository>();
		services.AddScoped<IFollowRepository, FollowRepository>();
		services.AddScoped<ILikeRepository, LikeRepository>();
		services.AddScoped<IMessageRepository, MessageRepository>();
		services.AddScoped<INotificationRepository, NotificationRepository>();
		services.AddScoped<IRetweetRepository, RetweetRepository>();
		return services;
	}
}
