using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories;

public class MessageRepository(TwitterCloneDbContext context) :
    IMessageRepository {
	public Message AddMessage(Message message) {
		context.Messages.Add(message);
		context.SaveChanges();
		return message;
	}

	public bool DeleteMessage(Message message) {
		context.Messages.Remove(message);
		return context.SaveChanges() == 1;
	}

	public int DeleteMessagesByUserId(Guid userId) {
		var messages =
		    context.Messages
		        .Where(m => m.SenderId == userId || m.ReceiverId == userId)
		        .ToList();

		context.Messages.RemoveRange(messages);
		return context.SaveChanges();
	}

	public Message? GetMessageById(Guid id) =>
	    context.Messages.SingleOrDefault(m => m.Id == id);

	public List<Message> GetMessages(Guid? senderId, Guid? recieverId) => [
	        ..context.Messages.Where(
	            m => (senderId == null || m.SenderId == senderId)
	              && (recieverId == null || m.ReceiverId == recieverId))];

	// Messages exchanged between two users, in either direction.
	public List<Message> GetConversation(Guid userId, Guid otherUserId) => [
	        ..context.Messages.Where(
	            m => (m.SenderId == userId && m.ReceiverId == otherUserId)
	              || (m.SenderId == otherUserId && m.ReceiverId == userId))];

	public Message UpdateMessage(Message message) {
		context.Messages.Update(message);
		context.SaveChanges();
		return message;
	}
}
