using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotificationsController : ControllerBase {
	[HttpGet]
	public IActionResult GetNotifications() {
		var likeUserId = Guid.NewGuid();
		var tweetId    = Guid.NewGuid();
		var followerId = Guid.NewGuid();
		var senderId   = Guid.NewGuid();

		var notifications = new List<Notification> {
			new LikeNotification(likeUserId, tweetId),
			new FollowNotification(likeUserId, followerId),
			new MentionNotification(likeUserId, tweetId),
		};

		return Ok(notifications);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetNotificationById(Guid id) {
		var notification = (Notification)new SystemNotification(Guid.NewGuid(), "Sample system notification");
		return Ok(notification);
	}

	[HttpPost]
	public IActionResult CreateNotification([FromBody] Notification notification) {
		return CreatedAtAction(nameof(GetNotificationById), new { id = notification.Id }, notification);
	}

	[HttpPatch("{id:guid}/read")]
	public IActionResult MarkAsRead(Guid id) {
		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteNotification(Guid id) {
		return NoContent();
	}
}
