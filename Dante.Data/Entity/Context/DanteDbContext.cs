using Microsoft.EntityFrameworkCore;

namespace Dante.Data.Entity.Context
{
	public class DanteDbContext: DbContext
	{
		public DanteDbContext(DbContextOptions<DanteDbContext> options): base(options) {}

		public virtual DbSet<User> Users { get; set; }

		// public virtual DbSet<Role> Roles { get; set; }

		public virtual DbSet<Tweet> Tweets { get; set; }

		public virtual DbSet<Following> Following { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var roles = new List<Role>()
			{
				new Role()
				{
					Id = Guid.Parse("3b4b5be4-d0aa-4311-80ad-97df2456d884"),
					Name = "User",
					Description = "Basic user with access to the site and all its features."
				},
				new Role()
				{
					Id = Guid.Parse("5072fd20-45c5-480f-b4f9-5a768d70b879"),
					Name = "Admin",
					Description = "Admin with ability to make site changes as needed."
				}
			};

			modelBuilder.Entity<Role>().HasData(roles);
		}
	}
}

	