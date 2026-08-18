namespace TwitterClone.Domain.Entities;

public sealed class ReplyNotification(Guid userId, Guid tweetId) : Notification
(userId, "Reply", NotificationType.Reply) {
	public Guid TweetId { get; set; } = tweetId;

	public override string GetMessage() {
		return $"User {UserId} replied to your tweet {TweetId}";
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nReplyNotification: UserId: {UserId}, TweetId: {TweetId}";
	}
}