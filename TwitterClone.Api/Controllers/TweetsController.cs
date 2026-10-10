using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TweetsController(ITweetService tweetService) : ControllerBase {
	[HttpPost]
	public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto) {
		var createdTweet = tweetService.CreateTweet(createTweetDto);
		if (createdTweet is null)
			return BadRequest();
		return Ok(createdTweet);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteTweetById([FromRoute] Guid id) {
		var tweet = tweetService.GetTweetById(id);

		if (tweet == null)
			return NotFound();

		return Ok(tweetService.DeleteTweetById(id));
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetTweetById([FromRoute] Guid id) {
		var tweet = tweetService.GetTweetById(id);

		if (tweet == null)
			return NotFound();

		return Ok(tweet);
	}

	[HttpGet]
	public IActionResult GetTweets() { return Ok(tweetService.GetTweets()); }

	[HttpPut("{id:guid}")]
	public IActionResult
	UpdateTweetById([FromRoute] Guid          id,
	                [FromBody] UpdateTweetDto updateTweetDto) {
		var tweet = tweetService.UpdateTweetById(id, updateTweetDto);

		if (tweet == null)
			return NotFound();

		return Ok(tweet);
	}
}
