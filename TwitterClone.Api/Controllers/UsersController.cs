using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IUserService userService) : ControllerBase {
	[HttpPost]
	public IActionResult CreateUser([FromBody] CreateUserDto createUserDto) {
		var createdUser = userService.CreateUser(createUserDto);
		if (createdUser is null)
			return BadRequest();
		return Ok(createdUser);
	}

	[HttpDelete("/api/user/{id:guid}")]
	public IActionResult DeleteUserById([FromRoute] Guid id) {
		var user = userService.GetUserById(id);

		if (user == null)
			return NotFound();

		return Ok(userService.DeleteUserById(id));
	}

	[HttpGet("/api/user/{id:guid}")]
	public IActionResult GetUserById([FromRoute] Guid id) {
		var user = userService.GetUserById(id);

		if (user == null)
			return NotFound();

		return Ok(user);
	}

	[HttpGet]
	public IActionResult GetUsers() { return Ok(userService.GetUsers()); }

	[HttpPut("/api/user/{id:guid}")]
	public IActionResult
	UpdateUserById([FromRoute] Guid         id,
	               [FromBody] UpdateUserDto updateUserDto) {
		return Ok();
		// var user = userService.GetUserById(id);
		//
		// if (user == null)
		// 	return NotFound();
		//
		// return Ok();
	}
}
