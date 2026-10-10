using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService {
	public UserDto? CreateUser(CreateUserDto createUserDto) {
		var firstName = createUserDto.FirstName;
		var lastName  = createUserDto.LastName;
		var userName  = createUserDto.UserName;
		var email     = createUserDto.Email;

		foreach(var e in new[] { firstName, lastName, userName, email }) {
			if (string.IsNullOrWhiteSpace(e))
				return null;
		}

		if (userRepository.GetUserByEmail(email) != null
		    || userRepository.GetUserByUserName(userName) != null)
			return null;

		userRepository.AddUser(new User(firstName, lastName, userName, email));

		return new UserDto(firstName, lastName, userName, email);
	}

	public bool DeleteUserById(Guid id) {
		var user = userRepository.GetUserById(id);

		if (user == null) {
			return false;
		}

		// A user's tweets can't outlive the user.
		// tweetRepository.DeleteTweetsByUserId(id);

		return userRepository.DeleteUser(user);
	}

	public UserDto? GetUserById(Guid id) {
		var user = userRepository.GetUserById(id);

		if (user is null)
			return null;

		return new UserDto(user);
	}

	public List<UserDto> GetUsers() => [..userRepository.GetUsers().Select(
	    user => new UserDto(user))];

	public UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto) {
		var user = userRepository.GetUserById(id);

		if (user == null) {
			return null;
		}

		user.FirstName = updateUserDto.FirstName.Trim();
		user.LastName  = updateUserDto.LastName.Trim();

		userRepository.UpdateUser(user);

		return new UserDto(user);
	}
}
