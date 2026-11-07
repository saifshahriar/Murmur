using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LikesController(ILikeService likeService) : ControllerBase {
	// GET /api/likes?userId={userId}&tweetId={tweetId}
	[HttpGet]
	[ProducesResponseType(typeof(List<LikeDto>), StatusCodes.Status200OK)]
	public IActionResult GetLikes([FromQuery] Guid? userId,
	                               [FromQuery] Guid? tweetId) {
		return Ok(likeService.GetLikes(userId, tweetId));
	}

	// GET /api/likes/{id}
	[HttpGet("{id:guid}")]
	[ProducesResponseType(typeof(LikeDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetLikeById([FromRoute] Guid id) {
		var like = likeService.GetLikeById(id);

		if (like == null)
			return NotFound();

		return Ok(like);
	}

	// POST /api/likes
	[HttpPost]
	[ProducesResponseType(typeof(LikeDto), StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public IActionResult CreateLike([FromBody] CreateLikeDto createLikeDto) {
		var createdLike = likeService.CreateLike(createLikeDto);

		if (createdLike == null)
			return BadRequest();

		return CreatedAtAction(nameof(GetLikeById), new { id = createdLike.Id },
		                       createdLike);
	}

	// DELETE /api/likes/{id}
	[HttpDelete("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult DeleteLike([FromRoute] Guid id) {
		var isDeleted = likeService.DeleteLike(id);

		if (!isDeleted)
			return NotFound();

		return NoContent();
	}
}
