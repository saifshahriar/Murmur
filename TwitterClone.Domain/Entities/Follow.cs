namespace TwitterClone.Domain.Entities;

public class Follow {
	public Guid     Id { get; } = Guid.NewGuid();
	public Guid     FollowingId { get; }
	public Guid     FollowerId { get; }
	public DateTime FollowedAt { get; } = DateTime.UtcNow;
}
