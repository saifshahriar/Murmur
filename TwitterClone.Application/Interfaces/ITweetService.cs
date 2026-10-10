using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces;

public interface ITweetService {
	public TweetDto? CreateTweet(CreateTweetDto createTweetDto);
	public bool DeleteTweetById(Guid id);
	public TweetDto? GetTweetById(Guid id);
	public List<TweetDto> GetTweets();
	public TweetDto? UpdateTweetById(Guid id, UpdateTweetDto updateTweetDto);
}
