namespace TwitterClone.Domain.Entities;

public sealed class RetweetNotification(Guid userId, Guid tweetId) :
    Notification
(userId, "Retweet", NotificationType.Retweet) {
	public Guid TweetId { get; set; } = tweetId;

	public override string GetMessage() {
		return $"User {UserId} retweeted your tweet {TweetId}";
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nRetweetNotification: UserId: {UserId}, TweetId: {TweetId}";
	}
}