using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces;

public interface IUserRepository {
	public User AddUser(User user);
	public bool DeleteUser(User user);
	public User? GetUserById(Guid id);
	public User? GetUserByEmail(string email);
	public User? GetUserByUserName(string userName);
	public List<User> GetUsers();
	public User       UpdateUser(User user);
}
