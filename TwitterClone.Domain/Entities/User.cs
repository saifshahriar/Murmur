namespace TwitterClone.Domain.Entities;

public class User(string firstName, string lastName, string userName,
                  string email) : BaseEntity(Guid.NewGuid()), IFollowable, INotifiable {
	public User() :
	    this(string.Empty, string.Empty, string.Empty, string.Empty) {}

	private readonly List<Guid> _followers = [];
	private readonly List<Guid> _inComingNotifications = [];

	public string FirstName { get; set; } = firstName;
	public string LastName { get; set; }  = lastName;
	public string UserName { get; set; }  = userName;
	public string Email { get; set; }     = email;

	public override string DescribeRecord() {
		return $"{base.DescribeRecord()}\nUser: FirstName: {FirstName}, LastName: {LastName}, UserName: {UserName}, Email: {Email}";
	}

	public void Follow(Guid userId) {
		if(!_followers.Contains(userId)) {
			_followers.Add(userId);
		}
	}

	public void Unfollow(Guid userId) {
		if(_followers.Contains(userId)) {
			_followers.Remove(userId);
		}
	}

	public void AddNotification(Guid notificationId) {
		if(!_inComingNotifications.Contains(notificationId)) {
			_inComingNotifications.Add(notificationId);
		}
	}
}
