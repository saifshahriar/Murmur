using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MessagesController(IMessageService messageService) : ControllerBase {
	// GET /api/messages?senderId={senderId}&recieverId={recieverId}
	[HttpGet]
	[ProducesResponseType(typeof(List<MessageDto>), StatusCodes.Status200OK)]
	public IActionResult GetMessages([FromQuery] Guid? senderId,
	                                  [FromQuery] Guid? recieverId) {
		return Ok(messageService.GetMessages(senderId, recieverId));
	}

	// GET /api/messages/{id}
	[HttpGet("{id:guid}")]
	[ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetMessageById([FromRoute] Guid id) {
		var message = messageService.GetMessageById(id);

		if (message == null)
			return NotFound();

		return Ok(message);
	}

	// GET /api/messages/conversation?userId={userId}&otherUserId={otherUserId}
	[HttpGet("conversation")]
	[ProducesResponseType(typeof(List<MessageDto>), StatusCodes.Status200OK)]
	public IActionResult GetConversation([FromQuery] Guid userId,
	                                     [FromQuery] Guid otherUserId) {
		return Ok(messageService.GetConversation(userId, otherUserId));
	}

	// POST /api/messages
	[HttpPost]
	[ProducesResponseType(typeof(MessageDto), StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public IActionResult SendMessage([FromBody] CreateMessageDto createMessageDto) {
		var sentMessage = messageService.SendMessage(createMessageDto);

		if (sentMessage == null)
			return BadRequest();

		return CreatedAtAction(nameof(GetMessageById),
		                       new { id = sentMessage.Id }, sentMessage);
	}

	// PUT /api/messages/{id}
	[HttpPut("{id:guid}")]
	[ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult UpdateMessage([FromRoute] Guid id,
	                                    [FromBody] UpdateMessageDto updateMessageDto) {
		var message = messageService.UpdateMessage(id, updateMessageDto);

		if (message == null)
			return NotFound();

		return Ok(message);
	}

	// PATCH /api/messages/{id}/read
	[HttpPatch("{id:guid}/read")]
	[ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult MarkMessageAsRead([FromRoute] Guid id) {
		var message = messageService.MarkMessageAsRead(id);

		if (message == null)
			return NotFound();

		return Ok(message);
	}

	// DELETE /api/messages/{id}
	[HttpDelete("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult DeleteMessage([FromRoute] Guid id) {
		var isDeleted = messageService.DeleteMessage(id);

		if (!isDeleted)
			return NotFound();

		return NoContent();
	}
}
