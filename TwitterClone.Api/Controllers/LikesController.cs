using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LikesController : ControllerBase {
	[HttpGet]
	public IActionResult GetLikes() {
		var likes = new List<Like> {
			new(),
			new(),
			new(),
		};

		return Ok(likes);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetLikeById(Guid id) {
		var like = new Like();
		return Ok(like);
	}

	[HttpPost]
	public IActionResult CreateLike([FromBody] Like like) {
		return CreatedAtAction(nameof(GetLikeById), new { id = like.Id }, like);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteLike(Guid id) {
		return NoContent();
	}
}
