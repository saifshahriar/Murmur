using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Dtos;

public class UpdateUserDto(string firstName, string lastName) {
	public required string FirstName { get; set; } = firstName;
	public required string LastName { get; set; }  = lastName;

	public UpdateUserDto(User user) : this(user.FirstName, user.LastName) {}
}
