using System;
using System.ComponentModel.DataAnnotations;

namespace Dante.API.Models
{
	public class LoginDto
	{
		[Required]
		[DataType(DataType.Text)]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}

