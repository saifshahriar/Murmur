namespace TwitterClone.Domain.Entities;

public class Bookmark {
	public Guid     Id { get; } = Guid.NewGuid();
	public Guid     TweetId { get; }
	public Guid     UserId { get; }
	public DateTime BookmarkedAt { get; } = DateTime.UtcNow;
}
