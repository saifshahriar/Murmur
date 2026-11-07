using Microsoft.Extensions.DependencyInjection;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;

namespace TwitterClone.Application;

public static class DependencyInjection {
	public static IServiceCollection
	AddApplication(this IServiceCollection services) {
		// Scoped, because the services consume repositories that are scoped
		// alongside the EF Core DbContext.
		services.AddScoped<IBookmarkService, BookmarkService>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<ITweetService, TweetService>();
		services.AddScoped<IFollowService, FollowService>();
		services.AddScoped<ILikeService, LikeService>();
		services.AddScoped<IMessageService, MessageService>();
		services.AddScoped<INotificationService, NotificationService>();
		services.AddScoped<IRetweetService, RetweetService>();
		return services;
	}
}
