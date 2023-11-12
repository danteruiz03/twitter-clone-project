using System;
using Dante.Data.Entity;

namespace Dante.Data.Repository.Interface
{
	public interface ITokenRepository
	{
        string CreateJWTToken(User user, string role);
    }
}

