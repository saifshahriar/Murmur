using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TwitterController(IConfiguration configuration) : ControllerBase {
	[HttpGet("tweets")]
	public IActionResult GetTweets() {
		var maxLength = configuration.GetValue<int>("TwitterSettings:MaxTweetLength");

		var tweets = new List<Tweet> {
			new("Hello, TwitterClone!"),
			new("Building something cool with ASP.NET Core."),
			new("C# is actually pretty nice."),
		};

		return Ok(new { maxLength, tweets });
	}
}
