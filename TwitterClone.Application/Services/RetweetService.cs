using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class RetweetService(IRetweetRepository retweetRepository,
                            IUserRepository    userRepository,
                            ITweetRepository   tweetRepository) : IRetweetService {
	public RetweetDto? CreateRetweet(CreateRetweetDto createRetweetDto) {
		var userId  = createRetweetDto.UserId;
		var tweetId = createRetweetDto.TweetId;
		var content = createRetweetDto.Content;

		if (userRepository.GetUserById(userId) == null)
			return null;

		if (tweetRepository.GetTweetById(tweetId) == null)
			return null;

		return retweetRepository
		    .AddRetweet(new Retweet(content, userId, tweetId))
		    .ToDto();
	}

	public RetweetDto? GetRetweetById(Guid id) {
		var retweet = retweetRepository.GetRetweetById(id);
		return retweet?.ToDto();
	}

	public List<RetweetDto> GetRetweets(Guid? userId, Guid? tweetId) {
		return [..retweetRepository.GetRetweets(userId, tweetId)
		        .OrderByDescending(r => r.CreatedAt)
		        .Select(r => r.ToDto())];
	}

	public RetweetDto? UpdateRetweet(Guid id,
	                                 UpdateRetweetDto updateRetweetDto) {
		var retweet = retweetRepository.GetRetweetById(id);

		if (retweet == null)
			return null;

		retweet.Content = updateRetweetDto.Content;

		return retweetRepository.UpdateRetweet(retweet).ToDto();
	}

	public bool DeleteRetweet(Guid id) {
		var retweet = retweetRepository.GetRetweetById(id);

		if (retweet == null)
			return false;

		return retweetRepository.DeleteRetweet(retweet);
	}
}
