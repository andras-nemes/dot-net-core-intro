using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Domains
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int NumberOfPages { get; set; }
		public decimal Price { get; set; }
		public Genre Genre { get; set; }
	}
}
