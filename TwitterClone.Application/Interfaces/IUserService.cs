using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces;

public interface IUserService {
	UserDto? CreateUser(CreateUserDto createUserDto);
	bool DeleteUserById(Guid id);
	UserDto? GetUserById(Guid id);
	List<UserDto> GetUsers();
	UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto);
}
