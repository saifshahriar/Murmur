namespace TwitterClone.Domain.Entities;

public sealed class LikeNotification(Guid userId, Guid tweetId) : Notification
(userId, "Like", NotificationType.Like) {
	public Guid TweetId { get; set; } = tweetId;

	public override string GetMessage() {
		return $"User {UserId} liked your tweet {TweetId}";
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nLikeNotification: UserId: {UserId}, TweetId: {TweetId}";
	}
}