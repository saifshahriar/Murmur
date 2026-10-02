using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Dtos;

public class UserDto(Guid id, string firstName, string lastName,
                     string userName, string email) {
	public Guid   Id { get; }        = id;
	public string FirstName { get; } = firstName;
	public string LastName { get; }  = lastName;
	public string UserName { get; }  = userName;
	public string Email { get; }     = email;

	public static UserDto FromUser(User user) => new(user.Id, user.FirstName,
	                                                 user.LastName,
	                                                 user.UserName, user.Email);
}
