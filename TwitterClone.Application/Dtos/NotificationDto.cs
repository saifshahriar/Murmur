using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Dtos;

public class NotificationDto {
	public required Guid Id { get; set; }
	public required Guid UserId { get; set; }
	public required NotificationType Type { get; set; }
	public required string Content { get; set; }
	public bool IsRead { get; set; }
	public DateTime CreatedAt { get; set; }
}
