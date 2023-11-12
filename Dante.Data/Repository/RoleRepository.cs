using Dante.Data.Entity;
using Dante.Data.Entity.Context;
using Dante.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dante.Data.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly DanteDbContext _dbContext;

    public RoleRepository(DanteDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Role> GetUserRole()
    {
        var userRole = Constants.Constants.User;
        return await _dbContext.Roles.FirstAsync(r => r.Name == userRole);
    }
}