using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Dtos;

public class UserDto(string firstName, string lastName, string userName,
                     string email) {
	public string FirstName { get; } = firstName;
	public string LastName { get; }  = lastName;
	public string UserName { get; }  = userName;
	public string Email { get; }     = email;

	public UserDto(User user) :
	    this(user.FirstName, user.LastName, user.UserName, user.Email) {}

	public static UserDto FromUser(User user) => new(user.FirstName,
	                                                 user.LastName,
	                                                 user.UserName, user.Email);
}
