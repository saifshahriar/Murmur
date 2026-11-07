using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Dtos;

public class CreateNotificationDto {
	public required Guid UserId { get; set; }
	public required NotificationType Type { get; set; }

	// The user that triggered the notification - the one who liked,
	// retweeted, followed, mentioned, replied or commented.
	public required Guid TriggeredByUserId { get; set; }

	// The tweet the notification refers to, for the types that have one.
	public Guid? TweetId { get; set; }

	// Extra text, used by comment and system notifications.
	public string? Message { get; set; }
}
