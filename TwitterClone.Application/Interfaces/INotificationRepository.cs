using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces;

public interface INotificationRepository {
	Notification AddNotification(Notification notification);
	bool DeleteNotification(Notification notification);
	int DeleteNotificationsByUserId(Guid userId);
	Notification? GetNotificationById(Guid id);
	List<Notification> GetNotifications(Guid? userId, NotificationType? type,
	                                    bool? isRead);
	bool MarkAsRead(Notification notification);
	int MarkAllAsReadByUserId(Guid userId);
}
