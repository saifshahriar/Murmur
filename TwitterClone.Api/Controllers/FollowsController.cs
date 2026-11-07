using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FollowsController(IFollowService followService) : ControllerBase {
	// GET /api/follows?followerId={followerId}&followingId={followingId}
	[HttpGet]
	[ProducesResponseType(typeof(List<FollowDto>), StatusCodes.Status200OK)]
	public IActionResult GetFollows([FromQuery] Guid? followerId,
	                                [FromQuery] Guid? followingId) {
		return Ok(followService.GetFollows(followerId, followingId));
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetFollowById(Guid id) {
		var follow = new Follow();
		return Ok(follow);
	}

	[HttpPost]
	public IActionResult CreateFollow([FromBody] Follow follow) {
		return CreatedAtAction(nameof(GetFollowById), new { id = follow.Id },
		                       follow);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteFollow(Guid id) { return NoContent(); }
}
