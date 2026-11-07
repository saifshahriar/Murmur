using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories;

public class LikeRepository(TwitterCloneDbContext context) : ILikeRepository {
	public Like AddLike(Like like) {
		context.Likes.Add(like);
		context.SaveChanges();
		return like;
	}

	public bool DeleteLike(Like like) {
		context.Likes.Remove(like);
		return context.SaveChanges() == 1;
	}

	public int DeleteLikesByUserId(Guid userId) {
		var likes = context.Likes.Where(l => l.UserId == userId).ToList();

		context.Likes.RemoveRange(likes);
		return context.SaveChanges();
	}

	public int DeleteLikesByTweetId(Guid tweetId) {
		var likes = context.Likes.Where(l => l.TweetId == tweetId).ToList();

		context.Likes.RemoveRange(likes);
		return context.SaveChanges();
	}

	public Like? GetLikeById(Guid id) =>
	    context.Likes.SingleOrDefault(l => l.Id == id);

	public Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId) =>
	    context.Likes.FirstOrDefault(l => l.UserId == userId
	                                     && l.TweetId == tweetId);

	public List<Like> GetLikes(Guid? userId, Guid? tweetId) => [
	        ..context.Likes.Where(
	            l => (userId == null || l.UserId == userId)
	              && (tweetId == null || l.TweetId == tweetId))];
}
