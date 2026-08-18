namespace TwitterClone.Domain.Entities;

public sealed class DirectMessageNotification(Guid userId, Guid senderId,
                                              string message) : Notification
(userId, "Message", NotificationType.Message) {
	public Guid   SenderId { get; set; } = senderId;
	public string Message { get; set; }  = message;

	public override string GetMessage() {
		return $"User {SenderId} sent you a message: {Message}";
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nDirectMessageNotification: SenderId: {SenderId}, Message: {Message}";
	}
}