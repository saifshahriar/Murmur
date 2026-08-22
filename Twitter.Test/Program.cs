using TwitterClone.Domain.Entities;

List<Notification> notifications = [
	new LikeNotification(Guid.NewGuid(), Guid.NewGuid()),
	new RetweetNotification(Guid.NewGuid(), Guid.NewGuid()),
	new FollowNotification(Guid.NewGuid(), Guid.NewGuid()),
	new MentionNotification(Guid.NewGuid(), Guid.NewGuid()),
	new ReplyNotification(Guid.NewGuid(), Guid.NewGuid()),
	new DirectMessageNotification(Guid.NewGuid(), Guid.NewGuid(), "Hello"),
	new CommentNotification(Guid.NewGuid(), Guid.NewGuid()),
	new SystemNotification(Guid.NewGuid(), "Welcome to Murmur!")
];

foreach(var notification in notifications) {
	Console.WriteLine(notification.GetNotificationInfo());
	Console.WriteLine(notification.GetMessage());
	Console.WriteLine();
}

Tweet likeableTweet = new("This is another tweet!");
Console.WriteLine($"Can be liked: {likeableTweet.CanBeLiked()}");
Console.WriteLine();

User follower = new("Saif", "Shahriar", "saifshahriar", "sh.saif@proton.me");
User followed = new("Mehraj", "Shakil", "mehrajshakil", "mehraj@example.com");
followed.Follow(follower.Id);
followed.AddNotification(Guid.NewGuid());
Console.WriteLine(followed.DescribeRecord());
