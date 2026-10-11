using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data;

public class TweetRepository {
	private List<Tweet> _tweets { get; set; } = [];

	public Tweet AddTweet(Tweet tweet) {
		_tweets.Add(tweet);
		return tweet;
	}

	public bool DeleteTweet(Tweet tweet) { return _tweets.Remove(tweet); }

	public Tweet? GetTweetById(Guid id) {
		return _tweets.SingleOrDefault(e => e.Id == id);
	}

	public List<Tweet> GetTweets() { return _tweets; }

	public Tweet UpdateTweet(Tweet tweet) {
		_tweets.RemoveAll(e => e.Id == tweet.Id);
		_tweets.Add(tweet);
		return tweet;
	}
}