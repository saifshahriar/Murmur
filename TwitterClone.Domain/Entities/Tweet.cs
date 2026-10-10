namespace TwitterClone.Domain.Entities;

public class Tweet(Guid userId, string content) : BaseEntity(Guid.NewGuid()),
                                                ILikeable {
	public Guid UserId { get; set; }     = userId;
	public string Content { set; get; } = content;

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nTweet: AuthorId: {UserId}, Content: {Content}";
	}

	public bool CanBeLiked() {
		return !string.IsNullOrWhiteSpace(Content);
	}
}
