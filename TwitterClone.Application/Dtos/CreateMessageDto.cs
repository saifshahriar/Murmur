namespace TwitterClone.Application.Dtos;

public class CreateMessageDto {
	public required Guid SenderId { get; set; }
	public required Guid RecieverId { get; set; }
	public required string Content { get; set; }
}
