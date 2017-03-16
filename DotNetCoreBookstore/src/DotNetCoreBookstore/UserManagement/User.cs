using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DotNetCoreBookstore.UserManagement
{
	public class User : IdentityUser
    {
		public int YearOfBirth { get; set; }
	}
}
