using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBookstore.UserManagement
{
    public class UserManagementDbContext : IdentityDbContext<User>
    {
		public UserManagementDbContext(DbContextOptions<UserManagementDbContext> dbContextOptions) : base(dbContextOptions)
		{ 
					
		}
    }
}
