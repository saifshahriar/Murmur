using TwitterClone.Domain.Entities;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Repositories;

public class UserRepository : IUserRepository {
	private List<User> _users { get; set; } = [];

	public User AddUser(User user) {
		_users.Add(user);
		return user;
	}

	public bool DeleteUser(User user) { return _users.Remove(user); }

	public User? GetUserById(Guid id) {
		return _users.SingleOrDefault(e => e.Id == id);
	}

	public User? GetUserByEmail(string email) {
		return _users.SingleOrDefault(e => e.Email == email);
	}

	public User? GetUserByUserName(string userName) {
		return _users.SingleOrDefault(e => e.UserName == userName);
	}

	public List<User> GetUsers() { return _users; }

	public User UpdateUser(User user) {
		_users.RemoveAll(e => e.Id == user.Id);
		_users.Add(user);
		return user;
	}
}
