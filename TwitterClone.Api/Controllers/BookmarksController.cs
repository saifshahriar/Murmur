using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookmarksController : ControllerBase {
	[HttpGet]
	public IActionResult GetBookmarks() {
		var bookmarks = new List<Bookmark> {
			new(),
			new(),
			new(),
		};

		return Ok(bookmarks);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetBookmarkById(Guid id) {
		var bookmark = new Bookmark();
		return Ok(bookmark);
	}

	[HttpPost]
	public IActionResult CreateBookmark([FromBody] Bookmark bookmark) {
		return CreatedAtAction(nameof(GetBookmarkById), new { id = bookmark.Id }, bookmark);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteBookmark(Guid id) {
		return NoContent();
	}
}
