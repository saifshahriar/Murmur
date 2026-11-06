using TwitterClone.Application.Dtos;
using TwitterClone.Application.Mappings;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class BookmarkService(IBookmarkRepository bookmarkRepository,
                             IUserRepository     userRepository,
                             ITweetRepository    tweetRepository) :
    IBookmarkService {
	public BookmarkDto? CreateBookmark(CreateBookmarkDto createBookmarkDto) {
		if (userRepository.GetUserById(createBookmarkDto.UserId) == null
		    || tweetRepository.GetTweetById(createBookmarkDto.TweetId)
		           == null) {
			return null;
		}

		var existingBookmark = bookmarkRepository.GetBookmarkByUserAndTweet(
		    createBookmarkDto.UserId, createBookmarkDto.TweetId);

		if (existingBookmark != null)
			return existingBookmark.ToDto();

		return bookmarkRepository
		    .AddBookmark(new Bookmark() { UserId  = createBookmarkDto.UserId,
			                              TweetId = createBookmarkDto.TweetId })
		    .ToDto();
	}

	public BookmarkDto? GetBookmarkById(Guid id) {
		var bookmark = bookmarkRepository.GetBookmarkById(id);
		return bookmark?.ToDto();
	}

	public List<BookmarkDto> GetBookmarks(Guid? userId) {
		return [..bookmarkRepository.GetBookmarks(userId)
			        .OrderByDescending(b => b.CreatedAt)
			        .Select(b => b.ToDto())];
	}

	public bool DeleteBookmark(Guid id) {
		var bookmark = bookmarkRepository.GetBookmarkById(id);

		if (bookmark == null)
			return false;

		return bookmarkRepository.DeleteBookmark(bookmark);
	}
}
