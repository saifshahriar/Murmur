using Microsoft.AspNetCore.Mvc;
using TwitterClone.Infrastructure.Data;
using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(UserRepository userRepository) : ControllerBase {
	[HttpPost]
	public IActionResult CreateUser([FromBody] CreateUserDto createUserDto) {
		var firstName = createUserDto.FirstName;
		var lastName  = createUserDto.LastName;
		var userName  = createUserDto.UserName;
		var email     = createUserDto.Email;

		foreach(var e in new[] { firstName, lastName, userName, email }) {
			if (string.IsNullOrWhiteSpace(e))
				return BadRequest("Required fields are missing");
		}

		if (userRepository.GetUserByEmail(email) != null)
			return BadRequest("Email exists");

		if (userRepository.GetUserByUserName(userName) != null)
			return BadRequest("Username taken");

		var user        = new User(firstName, lastName, userName, email);
		var createdUser = userRepository.AddUser(user);
		return Ok(UserDto.FromUser(createdUser));
	}

	[HttpDelete("/api/user/{id:guid}")]
	public IActionResult DeleteUserById([FromRoute] Guid id) {
		var user = userRepository.GetUserById(id);

		if (user == null)
			return NotFound();

		return Ok(userRepository.DeleteUser(user));
	}

	[HttpGet("/api/user/{id:guid}")]
	public IActionResult GetUserById([FromRoute] Guid id) {
		var user = userRepository.GetUserById(id);

		if (user == null)
			return NotFound();

		return Ok(UserDto.FromUser(user));
	}

	[HttpGet]
	public IActionResult GetUsers() {
		var users = userRepository.GetUsers();
		return Ok(users.Select(UserDto.FromUser));
	}

	[HttpPut("/api/user/{id:guid}")]
	public IActionResult
	UpdateUserById([FromRoute] Guid         id,
	               [FromBody] UpdateUserDto updateUserDto) {
		var user = userRepository.GetUserById(id);

		if (user == null)
			return NotFound();

		user.FirstName = updateUserDto.FirstName;
		user.LastName  = updateUserDto.LastName;

		var updatedUser = userRepository.UpdateUser(user);

		return Ok(UserDto.FromUser(updatedUser));
	}
}
