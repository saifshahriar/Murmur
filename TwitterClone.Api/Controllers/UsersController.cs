using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase {
	[HttpGet]
	public IActionResult GetUsers() {
		var users = new List<User> {
			new("Alice", "Johnson", "alicej", "alice@example.com"),
			new("Bob", "Smith", "bobsmith", "bob@example.com"),
			new("Charlie", "Brown", "charlieb", "charlie@example.com"),
		};

		return Ok(users);
	}
}
