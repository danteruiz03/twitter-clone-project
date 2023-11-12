using System;
using Dante.Data.Entity;

namespace Dante.Data.Repository.Interface
{
	public interface IUserRepository
	{
		Task<User?> GetUserByUserName(string username);

		Task<bool> CheckPasswordAsync(User user, string password);

		Task CreateUser(User user, Role role);
	}
}

