using Microsoft.EntityFrameworkCore;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence;

public class TwitterCloneDbContext(
    DbContextOptions<TwitterCloneDbContext> options) : DbContext
(options) {
	public DbSet<Bookmark>     Bookmarks { get; set; }
	public DbSet<Follow>       Follows { get; set; }
	public DbSet<Like>         Likes { get; set; }
	public DbSet<Message>      Messages { get; set; }
	public DbSet<Notification> Notifications { get; set; }
	public DbSet<Retweet>      Retweets { get; set; }
	public DbSet<Tweet>        Tweets { get; set; }
	public DbSet<User>         Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(
		    typeof(TwitterCloneDbContext).Assembly);

		// Notification is abstract, so its kinds have to be registered
		// explicitly - they are not discovered from the base configuration.
		// They share one table, discriminated by the Type column.
		AddDerivedNotification<LikeNotification>(modelBuilder,
			NotificationType.Like);
		AddDerivedNotification<RetweetNotification>(modelBuilder,
			NotificationType.Retweet);
		AddDerivedNotification<FollowNotification>(modelBuilder,
			NotificationType.Follow);
		AddDerivedNotification<MentionNotification>(modelBuilder,
			NotificationType.Mention);
		AddDerivedNotification<ReplyNotification>(modelBuilder,
			NotificationType.Reply);
		AddDerivedNotification<DirectMessageNotification>(modelBuilder,
			NotificationType.Message);
		AddDerivedNotification<CommentNotification>(modelBuilder,
			NotificationType.Comment);
		AddDerivedNotification<SystemNotification>(modelBuilder,
			NotificationType.System);
	}

	// Registers a notification kind as a derived type of Notification and
	// gives it its discriminator value. The value cannot be inferred from the
	// CLR type, because the discriminator is the Type enum property.
	private static void AddDerivedNotification<TNotification>(
		ModelBuilder      modelBuilder,
		NotificationType  discriminatorValue)
		where TNotification : Notification {
		var builder = modelBuilder.Entity<TNotification>()
			.HasBaseType<Notification>();

		builder.Metadata.SetDiscriminatorValue(discriminatorValue);
	}
}
