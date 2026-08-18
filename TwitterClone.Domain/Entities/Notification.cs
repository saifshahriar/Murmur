namespace TwitterClone.Domain.Entities;

public abstract class Notification(Guid userId, string content, NotificationType type) : BaseEntity
(Guid.NewGuid()) {
	public Guid             UserId { get; } = userId;
	public NotificationType Type { get; private set; } = type;
	public string           Content { set; get; }      = content;
	public bool             IsRead { get; set; }       = false;

	public abstract string GetMessage();

	public string GetNotificationInfo() {
		return $"UserId: {UserId}, Type: {Type}";
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nNotification: UserId: {UserId}, Type: {Type}, Content: {Content}, IsRead: {IsRead}";
	}
}
