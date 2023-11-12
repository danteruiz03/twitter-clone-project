using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dante.Data.Entity.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DanteDbContext>
    {
        public DanteDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Dante.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<DanteDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new DanteDbContext(builder.Options);
        }
    }
}

