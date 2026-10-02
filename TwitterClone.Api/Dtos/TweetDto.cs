using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Dtos;

public class TweetDto(Guid id, Guid userId, string content, DateTime createdAt,
                      DateTime? modifiedAt) {
	public Guid     Id         { get; } = id;
	public Guid     UserId     { get; } = userId;
	public string   Content    { get; } = content;
	public DateTime CreatedAt  { get; } = createdAt;
	public DateTime? ModifiedAt { get; } = modifiedAt;

	public static TweetDto FromTweet(Tweet tweet) =>
		new(tweet.Id, tweet.UserId, tweet.Content, tweet.CreatedAt, tweet.ModifiedAt);
}