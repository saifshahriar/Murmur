using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories;

public class MessageRepository : IMessageRepository {
	private readonly List<Message> _messages = [];

	public Message AddMessage(Message message) {
		_messages.Add(message);
		return message;
	}

	public bool DeleteMessage(Message message) {
		return _messages.Remove(message);
	}

	public int DeleteMessagesByUserId(Guid userId) {
		return _messages.RemoveAll(m => m.SenderId == userId
		                                || m.RecieverId == userId);
	}

	public Message? GetMessageById(Guid id) {
		return _messages.SingleOrDefault(m => m.Id == id);
	}

	public List<Message> GetMessages(Guid? senderId, Guid? recieverId) {
		return [.._messages.Where(m => (senderId == null
		                                 || m.SenderId == senderId)
		                              && (recieverId == null
		                                  || m.RecieverId == recieverId))];
	}

	// Messages exchanged between two users, in either direction.
	public List<Message> GetConversation(Guid userId, Guid otherUserId) {
		return [.._messages.Where(m => (m.SenderId == userId
		                                 && m.RecieverId == otherUserId)
		                              || (m.SenderId == otherUserId
		                                  && m.RecieverId == userId))];
	}

	public Message UpdateMessage(Message message) {
		_messages.RemoveAll(m => m.Id == message.Id);
		_messages.Add(message);
		return message;
	}
}
