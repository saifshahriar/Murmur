namespace TwitterClone.Domain.Entities;

public class Tweet(string content) {
	public Tweet() : this(string.Empty) {}

	public Guid     Id { get; } = Guid.NewGuid();
	public Guid     AuthorId { get; }
	public DateTime CreatedAt { get; } = DateTime.UtcNow;

	public string Content { set; get; } = content;
}
