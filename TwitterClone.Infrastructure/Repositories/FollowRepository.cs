using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories;

public class FollowRepository(TwitterCloneDbContext context) :
    IFollowRepository {
	public Follow AddFollow(Follow follow) {
		context.Follows.Add(follow);
		context.SaveChanges();
		return follow;
	}

	public bool DeleteFollow(Follow follow) {
		context.Follows.Remove(follow);
		return context.SaveChanges() == 1;
	}

	// Removes the follows where the user is either side of the
	// relationship.
	public int DeleteFollowsByUserId(Guid userId) {
		var follows =
		    context.Follows
		        .Where(f => f.FollowerId == userId || f.FollowingId == userId)
		        .ToList();

		context.Follows.RemoveRange(follows);
		return context.SaveChanges();
	}

	public Follow? GetFollowById(Guid id) =>
	    context.Follows.SingleOrDefault(f => f.Id == id);

	public Follow? GetFollowByUsers(Guid followerId, Guid followingId) =>
	    context.Follows.FirstOrDefault(f => f.FollowerId == followerId
	                                     && f.FollowingId == followingId);

	public List<Follow> GetFollows(Guid? followerId, Guid? followingId) => [
	        ..context.Follows.Where(
	            f => (followerId == null || f.FollowerId == followerId)
	              && (followingId == null || f.FollowingId == followingId))];
}
