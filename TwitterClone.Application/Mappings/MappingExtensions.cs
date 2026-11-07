using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Mappings;

public static class MappingExtensions {
	// public static UserDto ToDto(this User user)
	//   {
	//       return new UserDto
	//       {
	//           Id = user.Id,
	//           FirstName = user.FirstName,
	//           LastName = user.LastName,
	//           Email = user.Email,
	//           PhoneNumber = user.PhoneNumber,
	//           CreatedAt = user.CreatedAt,
	//           ModifiedAt = user.ModifiedAt
	//       };
	//   }
	//
	//   public static TweetDto ToDto(this Tweet tweet)
	//   {
	//       return new TweetDto
	//       {
	//           Id = tweet.Id,
	//           UserId = tweet.UserId,
	//           Content = tweet.Content,
	//           CreatedAt = tweet.CreatedAt,
	//           ModifiedAt = tweet.ModifiedAt
	//       };
	//   }

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

	public static LikeDto ToDto(this Like like) {
		return new LikeDto { Id = like.Id, UserId = like.UserId,
			                 TweetId   = like.TweetId,
			                 CreatedAt = like.CreatedAt };
	}
}
