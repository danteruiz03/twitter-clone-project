using System;
namespace Dante.Data.Entity
{
	public class Tweet
	{
		public Guid Id { get; set; }

		public string Content { get; set; }

		public DateTime CreatedDate { get; set; }

		public Guid UserId { get; set; }

		public User User { get; set; }
	}
}

