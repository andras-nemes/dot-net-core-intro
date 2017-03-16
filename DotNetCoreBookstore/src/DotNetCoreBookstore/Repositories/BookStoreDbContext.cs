using DotNetCoreBookstore.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Repositories
{
    public class BookStoreDbContext : DbContext
    {
		public BookStoreDbContext(DbContextOptions<BookStoreDbContext> dbContextOptions) : base(dbContextOptions)
		{	
					
		}

		public DbSet<Book> Books { get; set; }
	}
}
