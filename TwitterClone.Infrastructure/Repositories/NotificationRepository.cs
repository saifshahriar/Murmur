using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories;

public class NotificationRepository(TwitterCloneDbContext context) :
    INotificationRepository {
	public Notification AddNotification(Notification notification) {
		context.Notifications.Add(notification);
		context.SaveChanges();
		return notification;
	}

	public bool DeleteNotification(Notification notification) {
		context.Notifications.Remove(notification);
		return context.SaveChanges() == 1;
	}

	public int DeleteNotificationsByUserId(Guid userId) {
		var notifications =
		    context.Notifications.Where(n => n.UserId == userId).ToList();

		context.Notifications.RemoveRange(notifications);
		return context.SaveChanges();
	}

	public Notification? GetNotificationById(Guid id) =>
	    context.Notifications.SingleOrDefault(n => n.Id == id);

	public bool MarkAsRead(Notification notification) {
		notification.IsRead = true;
		context.SaveChanges();
		return true;
	}

	public List<Notification> GetNotifications(Guid? userId,
	                                           NotificationType? type,
	                                           bool? isRead) => [
	        ..context.Notifications.Where(
	            n => (userId == null || n.UserId == userId)
	              && (type == null || n.Type == type)
	              && (isRead == null || n.IsRead == isRead))];

	public int MarkAllAsReadByUserId(Guid userId) {
		var notifications =
		    context.Notifications.Where(n => n.UserId == userId && !n.IsRead)
		        .ToList();

		foreach (var notification in notifications) {
			notification.IsRead = true;
		}

		context.SaveChanges();
		return notifications.Count;
	}
}
