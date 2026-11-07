namespace TwitterClone.Application.Dtos;

public class CreateRetweetDto {
	public required Guid UserId { get; set; }
	public required Guid TweetId { get; set; }
	public required string Content { get; set; }
}
