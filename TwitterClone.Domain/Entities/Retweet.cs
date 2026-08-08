namespace TwitterClone.Domain.Entities;

public class Retweet(string content) {
	public Retweet() : this(string.Empty) {}

	public Guid     Id { get; } = Guid.NewGuid();
	public Guid     AuthorId { get; }
	public Guid     TweetId { get; }
	public DateTime CreatedAt { get; } = DateTime.UtcNow;

	public string Content { set; get; } = content;
}
