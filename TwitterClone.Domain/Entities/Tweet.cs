namespace TwitterClone.Domain.Entities;

public class Tweet(string content) : BaseEntity(Guid.NewGuid()), ILikeable {
	public Tweet() : this(string.Empty) {}

	public Guid UserId { get; }

	public string Content { set; get; } = content;

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nTweet: AuthorId: {UserId}, Content: {Content}";
	}

	public bool CanBeLiked() {
		return !string.IsNullOrWhiteSpace(Content);
	}
}
