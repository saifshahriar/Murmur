namespace TwitterClone.Domain.Entities;

public class Like {
	public Guid     Id { get; }        = Guid.NewGuid();
	public Guid     TweetId { get; }   = Guid.NewGuid();
	public DateTime CreatedAt { get; } = DateTime.UtcNow;
}
