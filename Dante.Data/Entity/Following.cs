namespace Dante.Data.Entity
{
	public class Following
	{
		public Guid Id { get; set; }


		public Guid? FollowingUserId { get; set; }

		public virtual User? FollowingUser { get; set; }


		public Guid? FollowerUserId { get; set; }

		public virtual User? FollowerUser { get; set; }


		public DateTime FollowDate { get; set; }
	}
}

