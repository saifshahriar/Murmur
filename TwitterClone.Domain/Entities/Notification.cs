namespace TwitterClone.Domain.Entities;

public class Notification(string content) {
	public Notification() : this(string.Empty) {}

	public Guid     Id { get; } = Guid.NewGuid();
	public Guid     UserId { get; }
	public string   Content { set; get; } = content;
	public DateTime NotifiedAt { get; }   = DateTime.UtcNow;
}
