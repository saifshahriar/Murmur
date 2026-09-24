using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RetweetsController : ControllerBase {
	[HttpGet]
	public IActionResult GetRetweets() {
		var retweets = new List<Retweet> {
			new("Retweeting this awesome content!"),
			new("Spreading the word."),
			new("Great insights here."),
		};

		return Ok(retweets);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetRetweetById(Guid id) {
		var retweet = new Retweet();
		return Ok(retweet);
	}

	[HttpPost]
	public IActionResult CreateRetweet([FromBody] Retweet retweet) {
		return CreatedAtAction(nameof(GetRetweetById), new { id = retweet.Id }, retweet);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteRetweet(Guid id) {
		return NoContent();
	}
}
