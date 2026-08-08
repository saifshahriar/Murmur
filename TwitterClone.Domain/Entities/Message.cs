namespace TwitterClone.Domain.Entities;

public class Message(string content) {
	public Message() : this(string.Empty) {}

	public Guid     Id { get; } = Guid.NewGuid();
	public Guid     SenderId { get; }
	public Guid     RecieverId { get; }
	public DateTime CreatedAt { get; } = DateTime.UtcNow;

	public string Content { set; get; } = content;
}
