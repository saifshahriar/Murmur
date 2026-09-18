using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TwitterController(IConfiguration configuration) : ControllerBase {
	private void GetTweet() {
		var connectionString =
		    configuration.GetValue<string>("Logging:LogLevel:Default") ?? "";
		Console.WriteLine(connectionString);
	}

	[HttpGet]
	public IActionResult GetTweets() {
		var tweets = new List<Tweet> {
			new("Hello, TwitterClone!"),
			new("Building something cool with ASP.NET Core."),
			new("C# is actually pretty nice."),
		};

		return Ok(tweets);
	}
}
