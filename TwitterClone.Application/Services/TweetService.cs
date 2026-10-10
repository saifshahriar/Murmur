using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class TweetService(ITweetRepository tweetRepository) : ITweetService {
	public TweetDto? CreateTweet(CreateTweetDto createTweetDto) {
		var userId  = createTweetDto.UserId;
		var content = createTweetDto.Content;

		if (string.IsNullOrWhiteSpace(content))
			return null;

		var tweet = new Tweet(userId, content);
		tweetRepository.AddTweet(tweet);

		return TweetDto.FromTweet(tweet);
	}

	public bool DeleteTweetById(Guid id) {
		var tweet = tweetRepository.GetTweetById(id);

		if (tweet == null)
			return false;

		return tweetRepository.DeleteTweet(tweet);
	}

	public TweetDto? GetTweetById(Guid id) {
		var tweet = tweetRepository.GetTweetById(id);

		if (tweet is null)
			return null;

		return TweetDto.FromTweet(tweet);
	}

	public List<TweetDto> GetTweets() => [..tweetRepository.GetTweets().Select(
	    tweet => TweetDto.FromTweet(tweet))];

	public TweetDto? UpdateTweetById(Guid id, UpdateTweetDto updateTweetDto) {
		var tweet = tweetRepository.GetTweetById(id);

		if (tweet == null)
			return null;

		tweet.Content = updateTweetDto.Content;

		var updatedTweet = tweetRepository.UpdateTweet(tweet);

		return TweetDto.FromTweet(updatedTweet);
	}
}
