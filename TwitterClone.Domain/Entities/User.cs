namespace TwitterClone.Domain.Entities;

public class User(string firstName, string lastName, string userName,
                  string email) {
	public User() :
	    this(string.Empty, string.Empty, string.Empty, string.Empty) {}

	public Guid     Id { get; }        = Guid.NewGuid();
	public DateTime CreatedAt { get; } = DateTime.UtcNow;

	public string FirstName { get; set; } = firstName;
	public string LastName { get; set; }  = lastName;
	public string UserName { get; set; }  = userName;
	public string Email { get; set; }     = email;
}
