using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Models
{
    public class UserRegistrationViewModel
    {
		[Required]
		public string Username { get; set; }
		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "Year of birth is required"), Range(1900, 2015)]
		public int YearOfBirth { get; set; }
	}
}
