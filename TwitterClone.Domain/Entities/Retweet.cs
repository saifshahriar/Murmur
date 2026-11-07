namespace TwitterClone.Domain.Entities;

public class Retweet : BaseEntity {
	public Retweet() : this(string.Empty, Guid.Empty, Guid.Empty) {}

	public Retweet(string content, Guid userId, Guid tweetId) :
	    base(Guid.NewGuid()) {
		Content = content;
		UserId  = userId;
		TweetId = tweetId;
	}

	public Guid UserId { get; private set; }
	public Guid TweetId { get; private set; }

	public string Content { set; get; }

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nRetweet: AuthorId: {UserId}, TweetId: {TweetId}, Content: {Content}";
	}
}
