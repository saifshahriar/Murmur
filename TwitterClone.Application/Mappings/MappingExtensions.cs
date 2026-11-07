using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Mappings;

public static class MappingExtensions {
	public static BookmarkDto ToDto(this Bookmark bookmark) {
		return new BookmarkDto { Id = bookmark.Id, UserId = bookmark.UserId,
			                     TweetId   = bookmark.TweetId,
			                     CreatedAt = bookmark.CreatedAt };
	}

	public static UserDto ToDto(this User user) {
		return UserDto.FromUser(user);
	}

	public static FollowDto ToDto(this Follow follow) {
		return new FollowDto { Id = follow.Id, FollowerId = follow.FollowerId,
			                   FollowingId = follow.FollowingId,
			                   CreatedAt   = follow.CreatedAt };
	}
}
