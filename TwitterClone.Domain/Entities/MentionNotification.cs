namespace TwitterClone.Domain.Entities;

public sealed class MentionNotification(Guid userId, Guid tweetId) :
    Notification
(userId, "Mention", NotificationType.Mention) {
	public Guid TweetId { get; set; } = tweetId;

	public override string GetMessage() {
		return $"User {UserId} mentioned you in tweet {TweetId}";
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nMentionNotification: UserId: {UserId}, TweetId: {TweetId}";
	}
}