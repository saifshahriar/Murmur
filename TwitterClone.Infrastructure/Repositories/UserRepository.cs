using TwitterClone.Domain.Entities;
using TwitterClone.Application.Interfaces;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories;

public class UserRepository(TwitterCloneDbContext context) : IUserRepository {
	public User AddUser(User user) {
		context.Users.Add(user);
		context.SaveChanges();
		return user;
	}

	public bool DeleteUser(User user) {
		context.Users.Remove(user);
		return context.SaveChanges() == 1;
	}

	public User? GetUserById(Guid id) => context.Users.SingleOrDefault(u => u.Id
	                                                                     == id);

	public User? GetUserByEmail(string email) =>
	    context.Users.SingleOrDefault(e => e.Email == email);

	public User? GetUserByUserName(string userName) =>
	    context.Users.SingleOrDefault(e => e.UserName == userName);

	public List<User> GetUsers() => [..context.Users];

	public User UpdateUser(User user) {
		context.Users.Update(user);
		context.SaveChanges();
		return user;
	}
}
