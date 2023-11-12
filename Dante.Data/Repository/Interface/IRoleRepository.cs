using Dante.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dante.Data.Repository.Interface;

public interface IRoleRepository
{
    // private readonly DbContext _dbContext;
    //
    // public IRoleRepository(DbContext dbContext)
    // {
    //     _dbContext = dbContext;
    // }

    Task<Role> GetUserRole();
}