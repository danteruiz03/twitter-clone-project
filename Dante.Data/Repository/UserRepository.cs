using System;
using Dante.Data.Entity;
using Dante.Data.Entity.Context;
using Dante.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dante.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DanteDbContext _dbContext;

        public UserRepository(DanteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var userResult = await _dbContext.Users.FindAsync(user.Id);
            return userResult?.Password == password;
        }
        
        public async Task CreateUser(User user, Role role)
        {
            user.Role = role;
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByUserName(string username)
        {
            return await _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}

