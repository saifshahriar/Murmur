using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Dtos;

public class TweetDto(Guid id, Guid userId, string content) {
	public Guid   Id      { get; } = id;
	public Guid   UserId  { get; } = userId;
	public string Content { get; } = content;

	public static TweetDto FromTweet(Tweet tweet) => new(tweet.Id, tweet.UserId,
	                                                     tweet.Content);
}
