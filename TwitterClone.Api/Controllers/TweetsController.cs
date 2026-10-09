using Microsoft.AspNetCore.Mvc;
using TwitterClone.Infrastructure.Data;
using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TweetsController(TweetRepository tweetRepository) :
    ControllerBase {
	[HttpPost]
	public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto) {
		var userId  = createTweetDto.UserId;
		var content = createTweetDto.Content;

		if (string.IsNullOrWhiteSpace(content))
			return BadRequest("Content is required");

		var tweet        = new Tweet(content) {};
		var createdTweet = tweetRepository.AddTweet(tweet);
		return Ok(TweetDto.FromTweet(createdTweet));
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteTweetById([FromRoute] Guid id) {
		var tweet = tweetRepository.GetTweetById(id);

		if (tweet == null)
			return NotFound();

		return Ok(tweetRepository.DeleteTweet(tweet));
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetTweetById([FromRoute] Guid id) {
		var tweet = tweetRepository.GetTweetById(id);

		if (tweet == null)
			return NotFound();

		return Ok(TweetDto.FromTweet(tweet));
	}

	[HttpGet]
	public IActionResult GetTweets() {
		var tweets = tweetRepository.GetTweets();
		return Ok(tweets.Select(TweetDto.FromTweet));
	}

	[HttpPut("{id:guid}")]
	public IActionResult
	UpdateTweetById([FromRoute] Guid          id,
	                [FromBody] UpdateTweetDto updateTweetDto) {
		var tweet = tweetRepository.GetTweetById(id);

		if (tweet == null)
			return NotFound();

		tweet.Content = updateTweetDto.Content;

		var updatedTweet = tweetRepository.UpdateTweet(tweet);

		return Ok(TweetDto.FromTweet(updatedTweet));
	}
}
