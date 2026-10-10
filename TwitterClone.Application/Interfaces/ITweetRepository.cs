using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces;

public interface ITweetRepository {
	public Tweet AddTweet(Tweet tweet);
	public bool  DeleteTweet(Tweet tweet);
	public Tweet? GetTweetById(Guid id);
	public List<Tweet> GetTweets();
	public Tweet       UpdateTweet(Tweet tweet);
}
