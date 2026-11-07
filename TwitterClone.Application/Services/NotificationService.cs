using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class NotificationService(INotificationRepository notificationRepository,
                                 IUserRepository        userRepository) :
    INotificationService {
	public NotificationDto? CreateNotification(
		CreateNotificationDto createNotificationDto) {
		var userId           = createNotificationDto.UserId;
		var type             = createNotificationDto.Type;
		var triggeredByUserId = createNotificationDto.TriggeredByUserId;
		var tweetId          = createNotificationDto.TweetId;
		var message          = createNotificationDto.Message;

		if (userRepository.GetUserById(userId) == null
		    || userRepository.GetUserById(triggeredByUserId) == null)
			return null;

		Notification? notification = type switch {
			NotificationType.Like    => new LikeNotification(userId,
			                                     tweetId ?? Guid.Empty),
			NotificationType.Retweet => new RetweetNotification(userId,
			                                       tweetId ?? Guid.Empty),
			NotificationType.Follow  => new FollowNotification(userId,
			                                       triggeredByUserId),
			NotificationType.Mention => new MentionNotification(userId,
			                                        tweetId ?? Guid.Empty),
			NotificationType.Reply   => new ReplyNotification(userId,
			                                      tweetId ?? Guid.Empty),
			NotificationType.Message => new DirectMessageNotification(userId,
			                                         triggeredByUserId,
			                                         message ?? string.Empty),
			NotificationType.Comment => new CommentNotification(userId,
			                                         triggeredByUserId),
			NotificationType.System  => new SystemNotification(userId,
			                                        message ?? string.Empty),
			_                        => null
		};

		if (notification == null)
			return null;

		if (notification is CommentNotification comment && message != null)
			comment.AddMessage(message);

		return notificationRepository.AddNotification(notification).ToDto();
	}

	public NotificationDto? GetNotificationById(Guid id) {
		var notification = notificationRepository.GetNotificationById(id);
		return notification?.ToDto();
	}

	public List<NotificationDto> GetNotifications(Guid? userId, string? type,
	                                               bool? isRead) {
		NotificationType? parsedType = null;

		if (!string.IsNullOrWhiteSpace(type)
		    && Enum.TryParse<NotificationType>(type, true, out var parsed))
			parsedType = parsed;

		return [..notificationRepository.GetNotifications(userId, parsedType,
		                                       isRead)
		        .OrderByDescending(n => n.CreatedAt)
		        .Select(n => n.ToDto())];
	}

	public NotificationDto? MarkNotificationAsRead(Guid id) {
		var notification = notificationRepository.GetNotificationById(id);

		if (notification == null)
			return null;

		notification.IsRead = true;

		return notification.ToDto();
	}

	public int MarkAllNotificationsAsRead(Guid userId) {
		return notificationRepository.MarkAllAsReadByUserId(userId);
	}

	public bool DeleteNotification(Guid id) {
		var notification = notificationRepository.GetNotificationById(id);

		if (notification == null)
			return false;

		return notificationRepository.DeleteNotification(notification);
	}
}
