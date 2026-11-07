using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository {
	private readonly List<Notification> _notifications = [];

	public Notification AddNotification(Notification notification) {
		_notifications.Add(notification);
		return notification;
	}

	public bool DeleteNotification(Notification notification) {
		return _notifications.Remove(notification);
	}

	public int DeleteNotificationsByUserId(Guid userId) {
		return _notifications.RemoveAll(n => n.UserId == userId);
	}

	public Notification? GetNotificationById(Guid id) {
		return _notifications.SingleOrDefault(n => n.Id == id);
	}

	public List<Notification> GetNotifications(Guid? userId,
	                                           NotificationType? type,
	                                           bool? isRead) {
		return [.._notifications.Where(n => (userId == null
		                                     || n.UserId == userId)
		                                  && (type == null || n.Type == type)
		                                  && (isRead == null
		                                      || n.IsRead == isRead))];
	}

	public int MarkAllAsReadByUserId(Guid userId) {
		var updated = 0;

		foreach (var notification in _notifications.Where(n => n.UserId == userId
		                                                     && !n.IsRead)) {
			notification.IsRead = true;
			updated++;
		}

		return updated;
	}
}
