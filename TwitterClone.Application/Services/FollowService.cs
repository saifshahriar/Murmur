using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class FollowService(IFollowRepository followRepository,
                          IUserRepository    userRepository) : IFollowService {
	public FollowDto? CreateFollow(CreateFollowDto createFollowDto) {
		var followerId  = createFollowDto.FollowerId;
		var followingId = createFollowDto.FollowingId;

		if (followerId == followingId)
			return null;

		if (userRepository.GetUserById(followerId) == null
		    || userRepository.GetUserById(followingId) == null)
			return null;

		var existingFollow = followRepository.GetFollowByUsers(followerId,
		                                                        followingId);

		if (existingFollow != null)
			return existingFollow.ToDto();

		return followRepository
		    .AddFollow(new Follow(followerId, followingId))
		    .ToDto();
	}

	public FollowDto? GetFollowById(Guid id) {
		var follow = followRepository.GetFollowById(id);
		return follow?.ToDto();
	}

	public List<FollowDto> GetFollows(Guid? followerId, Guid? followingId) {
		return [..followRepository.GetFollows(followerId, followingId)
		        .OrderByDescending(f => f.CreatedAt)
		        .Select(f => f.ToDto())];
	}

	public List<UserDto> GetFollowers(Guid userId) {
		return [..followRepository.GetFollows(null, userId)
		        .OrderByDescending(f => f.CreatedAt)
		        .Select(f => f.FollowerId)
		        .Distinct()
		        .Select(followerId => userRepository.GetUserById(followerId))
		        .Where(user => user != null)
		        .Select(user => user!.ToDto())];
	}

	public List<UserDto> GetFollowing(Guid userId) {
		return [..followRepository.GetFollows(userId, null)
		        .OrderByDescending(f => f.CreatedAt)
		        .Select(f => f.FollowingId)
		        .Distinct()
		        .Select(followingId => userRepository.GetUserById(followingId))
		        .Where(user => user != null)
		        .Select(user => user!.ToDto())];
	}

	public bool DeleteFollow(Guid id) {
		var follow = followRepository.GetFollowById(id);

		if (follow == null)
			return false;

		return followRepository.DeleteFollow(follow);
	}
}
