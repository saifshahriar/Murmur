namespace TwitterClone.Domain.Entities;

public class Like : BaseEntity {
	public Like() : base(Guid.NewGuid()) {}

	public Like(Guid userId, Guid tweetId) : base(Guid.NewGuid()) {
		UserId  = userId;
		TweetId = tweetId;
	}

	public Guid UserId  { get; private set; }
	public Guid TweetId { get; private set; }

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nLike: UserId: {UserId}, TweetId: {TweetId}";
	}
}
