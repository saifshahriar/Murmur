namespace TwitterClone.Domain.Entities;

public class Follow : BaseEntity {
	public Follow() : base(Guid.NewGuid()) {}

	public Follow(Guid followerId, Guid followingId) : base(Guid.NewGuid()) {
		FollowerId  = followerId;
		FollowingId = followingId;
	}

	public Guid FollowerId  { get; private set; }
	public Guid FollowingId { get; private set; }

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nFollow: FollowingId: {FollowingId}, FollowerId: {FollowerId}, FollowedAt: {CreatedAt}";
	}
}
