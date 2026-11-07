using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories;

public class RetweetRepository(TwitterCloneDbContext context) :
    IRetweetRepository {
	public Retweet AddRetweet(Retweet retweet) {
		context.Retweets.Add(retweet);
		context.SaveChanges();
		return retweet;
	}

	public bool DeleteRetweet(Retweet retweet) {
		context.Retweets.Remove(retweet);
		return context.SaveChanges() == 1;
	}

	public int DeleteRetweetsByUserId(Guid userId) {
		var retweets =
		    context.Retweets.Where(r => r.UserId == userId).ToList();

		context.Retweets.RemoveRange(retweets);
		return context.SaveChanges();
	}

	public int DeleteRetweetsByTweetId(Guid tweetId) {
		var retweets =
		    context.Retweets.Where(r => r.TweetId == tweetId).ToList();

		context.Retweets.RemoveRange(retweets);
		return context.SaveChanges();
	}

	public Retweet? GetRetweetById(Guid id) =>
	    context.Retweets.SingleOrDefault(r => r.Id == id);

	public List<Retweet> GetRetweets(Guid? userId, Guid? tweetId) => [
	        ..context.Retweets.Where(
	            r => (userId == null || r.UserId == userId)
	              && (tweetId == null || r.TweetId == tweetId))];

	public Retweet UpdateRetweet(Retweet retweet) {
		context.Retweets.Update(retweet);
		context.SaveChanges();
		return retweet;
	}
}
