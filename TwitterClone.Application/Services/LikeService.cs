using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class LikeService(ILikeRepository   likeRepository,
                         IUserRepository  userRepository,
                         ITweetRepository tweetRepository) : ILikeService {
	public LikeDto? CreateLike(CreateLikeDto createLikeDto) {
		var userId  = createLikeDto.UserId;
		var tweetId = createLikeDto.TweetId;

		if (userRepository.GetUserById(userId) == null)
			return null;

		var tweet = tweetRepository.GetTweetById(tweetId);

		if (tweet == null || !tweet.CanBeLiked())
			return null;

		var existingLike = likeRepository.GetLikeByUserAndTweet(userId,
		                                                        tweetId);

		if (existingLike != null)
			return existingLike.ToDto();

		return likeRepository
		    .AddLike(new Like(userId, tweetId))
		    .ToDto();
	}

	public LikeDto? GetLikeById(Guid id) {
		var like = likeRepository.GetLikeById(id);
		return like?.ToDto();
	}

	public List<LikeDto> GetLikes(Guid? userId, Guid? tweetId) {
		return [..likeRepository.GetLikes(userId, tweetId)
		        .OrderByDescending(l => l.CreatedAt)
		        .Select(l => l.ToDto())];
	}

	public bool DeleteLike(Guid id) {
		var like = likeRepository.GetLikeById(id);

		if (like == null)
			return false;

		return likeRepository.DeleteLike(like);
	}
}
