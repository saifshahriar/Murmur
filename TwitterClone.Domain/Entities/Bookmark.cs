namespace TwitterClone.Domain.Entities;

public class Bookmark : BaseEntity {
	public Bookmark() : base(Guid.NewGuid()) {}

	public Guid TweetId { get; set; }
	public Guid UserId { get; set; }

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nBookmark: TweetId: {TweetId}, UserId: {UserId}, CreatedAt: {CreatedAt}";
	}
}
