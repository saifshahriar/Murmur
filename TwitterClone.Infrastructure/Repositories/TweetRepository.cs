using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories;

public class TweetRepository(TwitterCloneDbContext context) : ITweetRepository {
	public Tweet AddTweet(Tweet tweet) {
		context.Tweets.Add(tweet);
		context.SaveChanges();
		return tweet;
	}

	public bool DeleteTweet(Tweet tweet) {
		context.Tweets.Remove(tweet);
		return context.SaveChanges() == 1;
	}

	public Tweet? GetTweetById(Guid id) {
		return context.Tweets.SingleOrDefault(e => e.Id == id);
	}

	public List<Tweet> GetTweets() { return [..context.Tweets]; }

	public Tweet UpdateTweet(Tweet tweet) {
		context.Tweets.Update(tweet);
		context.SaveChanges();
		return tweet;
	}
}
