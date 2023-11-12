namespace Dante.Data.Entity
{
	public class User
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public Guid RoleId { get; set; }

		public virtual Role Role { get; set; }
	}
}

