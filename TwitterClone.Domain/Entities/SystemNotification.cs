namespace TwitterClone.Domain.Entities;

public sealed class SystemNotification(Guid userId, string message) :
    Notification
(userId, "System", NotificationType.System) {
	public string Message { get; set; } = message;

	public override string GetMessage() {
		return Message;
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nSystemNotification: Message: {Message}";
	}
}
