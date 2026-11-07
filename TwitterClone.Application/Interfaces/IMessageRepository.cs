using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces;

public interface IMessageRepository {
	Message AddMessage(Message message);
	bool    DeleteMessage(Message message);
	int     DeleteMessagesByUserId(Guid userId);
	Message? GetMessageById(Guid id);
	List<Message> GetMessages(Guid? senderId, Guid? recieverId);
	List<Message> GetConversation(Guid userId, Guid otherUserId);
	Message UpdateMessage(Message message);
}
