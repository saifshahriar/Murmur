using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class MessageService(IMessageRepository messageRepository,
                            IUserRepository    userRepository) : IMessageService {
	public MessageDto? SendMessage(CreateMessageDto createMessageDto) {
		var senderId    = createMessageDto.SenderId;
		var recieverId  = createMessageDto.RecieverId;
		var content     = createMessageDto.Content;

		if (string.IsNullOrWhiteSpace(content))
			return null;

		if (senderId == recieverId)
			return null;

		if (userRepository.GetUserById(senderId) == null
		    || userRepository.GetUserById(recieverId) == null)
			return null;

		return messageRepository
		    .AddMessage(new Message(content, senderId, recieverId))
		    .ToDto();
	}

	public MessageDto? GetMessageById(Guid id) {
		var message = messageRepository.GetMessageById(id);
		return message?.ToDto();
	}

	public List<MessageDto> GetMessages(Guid? senderId, Guid? recieverId) {
		return [..messageRepository.GetMessages(senderId, recieverId)
		        .OrderByDescending(m => m.SentAt)
		        .Select(m => m.ToDto())];
	}

	public List<MessageDto> GetConversation(Guid userId, Guid otherUserId) {
		return [..messageRepository.GetConversation(userId, otherUserId)
		        .OrderBy(m => m.SentAt)
		        .Select(m => m.ToDto())];
	}

	public MessageDto? UpdateMessage(Guid id,
	                                 UpdateMessageDto updateMessageDto) {
		var message = messageRepository.GetMessageById(id);

		if (message == null)
			return null;

		if (string.IsNullOrWhiteSpace(updateMessageDto.Content))
			return null;

		message.Content = updateMessageDto.Content;

		return messageRepository.UpdateMessage(message).ToDto();
	}

	public MessageDto? MarkMessageAsRead(Guid id) {
		var message = messageRepository.GetMessageById(id);

		if (message == null)
			return null;

		message.IsRead = true;

		return messageRepository.UpdateMessage(message).ToDto();
	}

	public bool DeleteMessage(Guid id) {
		var message = messageRepository.GetMessageById(id);

		if (message == null)
			return false;

		return messageRepository.DeleteMessage(message);
	}
}
