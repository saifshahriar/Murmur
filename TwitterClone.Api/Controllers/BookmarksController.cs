using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookmarksController(IBookmarkService bookmarkService) :
    ControllerBase {
	// GET /api/bookmarks?userId={userId}
	[HttpGet]
	[ProducesResponseType(typeof(List<BookmarkDto>), StatusCodes.Status200OK)]
	public IActionResult GetBookmarks([FromQuery] Guid? userId) {
		return Ok(bookmarkService.GetBookmarks(userId));
	}

	// GET /api/bookmarks/{id}
	[HttpGet("{id:guid}")]
	[ProducesResponseType(typeof(BookmarkDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetBookmarkById(Guid id) {
		var bookmark = bookmarkService.GetBookmarkById(id);

		if (bookmark == null)
			return NotFound();

		return Ok(bookmark);
	}

	// POST /api/bookmarks
	[HttpPost]
	[ProducesResponseType(typeof(BookmarkDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public IActionResult
	CreateBookmark([FromBody] CreateBookmarkDto createBookmarkDto) {
		var createdBookmark = bookmarkService.CreateBookmark(createBookmarkDto);

		if (createdBookmark == null)
			return BadRequest();

		return CreatedAtAction(nameof(GetBookmarkById),
		                       new { id = createdBookmark.Id },
		                       createdBookmark);
	}

	// DELETE /api/bookmarks/{id}
	[HttpDelete("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult DeleteBookmark([FromRoute] Guid id) {
		var isDeleted = bookmarkService.DeleteBookmark(id);

		if (!isDeleted)
			return NotFound();

		return NoContent();
	}
}
