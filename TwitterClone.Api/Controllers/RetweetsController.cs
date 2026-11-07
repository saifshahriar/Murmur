using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RetweetsController(IRetweetService retweetService) : ControllerBase {
	// GET /api/retweets?userId={userId}&tweetId={tweetId}
	[HttpGet]
	[ProducesResponseType(typeof(List<RetweetDto>), StatusCodes.Status200OK)]
	public IActionResult GetRetweets([FromQuery] Guid? userId,
	                                 [FromQuery] Guid? tweetId) {
		return Ok(retweetService.GetRetweets(userId, tweetId));
	}

	// GET /api/retweets/{id}
	[HttpGet("{id:guid}")]
	[ProducesResponseType(typeof(RetweetDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetRetweetById([FromRoute] Guid id) {
		var retweet = retweetService.GetRetweetById(id);

		if (retweet == null)
			return NotFound();

		return Ok(retweet);
	}

	// POST /api/retweets
	[HttpPost]
	[ProducesResponseType(typeof(RetweetDto), StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public IActionResult
	CreateRetweet([FromBody] CreateRetweetDto createRetweetDto) {
		var createdRetweet = retweetService.CreateRetweet(createRetweetDto);

		if (createdRetweet == null)
			return BadRequest();

		return CreatedAtAction(nameof(GetRetweetById),
		                       new { id = createdRetweet.Id }, createdRetweet);
	}

	// PUT /api/retweets/{id}
	[HttpPut("{id:guid}")]
	[ProducesResponseType(typeof(RetweetDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult UpdateRetweet([FromRoute] Guid id,
	                                    [FromBody] UpdateRetweetDto updateRetweetDto) {
		var retweet = retweetService.UpdateRetweet(id, updateRetweetDto);

		if (retweet == null)
			return NotFound();

		return Ok(retweet);
	}

	// DELETE /api/retweets/{id}
	[HttpDelete("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult DeleteRetweet([FromRoute] Guid id) {
		var isDeleted = retweetService.DeleteRetweet(id);

		if (!isDeleted)
			return NotFound();

		return NoContent();
	}
}
