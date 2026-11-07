namespace TwitterClone.Application.Dtos;

public class RetweetDto {
	public required Guid Id { get; set; }
	public required Guid UserId { get; set; }
	public required Guid TweetId { get; set; }
	public required string Content { get; set; }
	public DateTime CreatedAt { get; set; }
}
