namespace TwitterClone.Domain.Entities;

public sealed class FollowNotification(Guid userId, Guid followerId) : Notification
(userId, "Follow", NotificationType.Follow) {
	public Guid FollowerId { get; set; } = followerId;

	public override string GetMessage() {
		return $"User {FollowerId} started following you";
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nFollowNotification: FollowerId: {FollowerId}";
	}
}