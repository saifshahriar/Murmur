using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MessagesController : ControllerBase {
	[HttpGet]
	public IActionResult GetMessages() {
		var messages = new List<Message> {
			new("Hey, how are you?"),
			new("Did you see the latest tweet?"),
			new("Let's catch up later."),
		};

		return Ok(messages);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetMessageById(Guid id) {
		var message = new Message();
		return Ok(message);
	}

	[HttpPost]
	public IActionResult CreateMessage([FromBody] Message message) {
		return CreatedAtAction(nameof(GetMessageById), new { id = message.Id }, message);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteMessage(Guid id) {
		return NoContent();
	}
}
