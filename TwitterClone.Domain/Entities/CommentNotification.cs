namespace TwitterClone.Domain.Entities;

public sealed class CommentNotification(Guid userId, Guid commentByUserId) :
    Notification
(userId, "Comment", NotificationType.Comment) {
	public Guid   CommentByUserId { get; set; } = commentByUserId;
	public string Message { get; set; }         = string.Empty;

	public void AddMessage(string message) {
		Message = message;
	}

	public override string GetMessage() {
		return $"User {CommentByUserId} commented: {Message}";
	}

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nCommentNotification: CommentByUserId: {CommentByUserId}, Message: {Message}";
	}
}