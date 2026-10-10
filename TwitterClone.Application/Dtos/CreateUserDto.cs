namespace TwitterClone.Application.Dtos;

public class CreateUserDto(string firstName, string LastName, string userName,
                           string email) {
	public required string FirstName { get; set; } = firstName;
	public required string LastName { get; set; }  = LastName;
	public required string UserName { get; set; }  = userName;
	public required string Email { get; set; }     = email;
}
