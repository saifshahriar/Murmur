using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FollowsController : ControllerBase {
	[HttpGet]
	public IActionResult GetFollows() {
		var follows = new List<Follow> {
			new(),
			new(),
			new(),
		};

		return Ok(follows);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetFollowById(Guid id) {
		var follow = new Follow();
		return Ok(follow);
	}

	[HttpPost]
	public IActionResult CreateFollow([FromBody] Follow follow) {
		return CreatedAtAction(nameof(GetFollowById), new { id = follow.Id }, follow);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteFollow(Guid id) {
		return NoContent();
	}
}
