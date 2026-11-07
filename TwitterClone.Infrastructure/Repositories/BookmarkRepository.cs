using TwitterClone.Domain.Entities;
using TwitterClone.Application.Interfaces;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories;

public class BookmarkRepository(TwitterCloneDbContext context) :
    IBookmarkRepository {
	public Bookmark AddBookmark(Bookmark bookmark) {
		context.Bookmarks.Add(bookmark);
		context.SaveChanges();
		return bookmark;
	}

	public bool DeleteBookmark(Bookmark bookmark) {
		context.Remove(bookmark);
		return context.SaveChanges() == 1;
	}

	public int DeleteBookmarksByUserId(Guid userId) {
		var bookmarks =
		    context.Bookmarks.Where(b => b.UserId == userId).ToList();

		context.Bookmarks.RemoveRange(bookmarks);
		return context.SaveChanges();
	}

	public int DeleteBookmarksByTweetId(Guid tweetId) {
		var bookmarks =
		    context.Bookmarks.Where(b => b.TweetId == tweetId).ToList();

		context.Bookmarks.RemoveRange(bookmarks);
		return context.SaveChanges();
	}

	public Bookmark? GetBookmarkById(Guid id) =>
	    context.Bookmarks.SingleOrDefault(b => b.Id == id);

	public Bookmark? GetBookmarkByUserAndTweet(Guid userId, Guid tweetId) =>
	    context.Bookmarks.FirstOrDefault(b => b.UserId == userId
	                                       && b.TweetId == tweetId);

	public List<Bookmark> GetBookmarks(Guid? userId) => [
	        ..context.Bookmarks.Where(b => userId == null || b.UserId == userId)
	        .ToList()];
}
