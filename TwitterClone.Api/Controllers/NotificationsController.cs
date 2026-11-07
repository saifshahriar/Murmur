using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotificationsController(INotificationService notificationService) :
    ControllerBase {
	// GET /api/notifications?userId={userId}&type={type}&isRead={isRead}
	[HttpGet]
	[ProducesResponseType(typeof(List<NotificationDto>), StatusCodes.Status200OK)]
	public IActionResult GetNotifications([FromQuery] Guid? userId,
	                                      [FromQuery] string? type,
	                                      [FromQuery] bool? isRead) {
		return Ok(notificationService.GetNotifications(userId, type, isRead));
	}

	// GET /api/notifications/{id}
	[HttpGet("{id:guid}")]
	[ProducesResponseType(typeof(NotificationDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetNotificationById([FromRoute] Guid id) {
		var notification = notificationService.GetNotificationById(id);

		if (notification == null)
			return NotFound();

		return Ok(notification);
	}

	// POST /api/notifications
	[HttpPost]
	[ProducesResponseType(typeof(NotificationDto), StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public IActionResult
	CreateNotification([FromBody] CreateNotificationDto createNotificationDto) {
		var createdNotification =
			notificationService.CreateNotification(createNotificationDto);

		if (createdNotification == null)
			return BadRequest();

		return CreatedAtAction(nameof(GetNotificationById),
		                       new { id = createdNotification.Id },
		                       createdNotification);
	}

	// PATCH /api/notifications/{id}/read
	[HttpPatch("{id:guid}/read")]
	[ProducesResponseType(typeof(NotificationDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult MarkNotificationAsRead([FromRoute] Guid id) {
		var notification = notificationService.MarkNotificationAsRead(id);

		if (notification == null)
			return NotFound();

		return Ok(notification);
	}

	// PATCH /api/notifications/read-all?userId={userId}
	[HttpPatch("read-all")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public IActionResult MarkAllNotificationsAsRead([FromQuery] Guid userId) {
		var updatedCount = notificationService.MarkAllNotificationsAsRead(userId);

		return Ok(new { UserId = userId, UpdatedCount = updatedCount });
	}

	// DELETE /api/notifications/{id}
	[HttpDelete("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult DeleteNotification([FromRoute] Guid id) {
		var isDeleted = notificationService.DeleteNotification(id);

		if (!isDeleted)
			return NotFound();

		return NoContent();
	}
}
