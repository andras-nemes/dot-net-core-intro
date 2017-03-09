using System;
using System.Collections.Generic;
using DotNetCoreBookstore.Domains;
using System.Linq;

namespace DotNetCoreBookstore.Repositories
{
	public class DebugBookRepository : IBookRepository
	{
		private List<Book> _testBooks;

		public DebugBookRepository()
		{
			_testBooks = new List<Book>();
			_testBooks.Add(new Book() { Id = 1, Author = "John Smith", Title = "C# for beginners", Genre = Genre.DotNet, NumberOfPages = 400, Price = 100 });
			_testBooks.Add(new Book() { Id = 2, Author = "Jane Cook", Title = "Java for beginners", Genre = Genre.Java, NumberOfPages = 450, Price = 150 });
			_testBooks.Add(new Book() { Id = 3, Author = "Mary Stone", Title = "F# for beginners", Genre = Genre.DotNet, NumberOfPages = 300, Price = 90 });
			_testBooks.Add(new Book() { Id = 4, Author = "Andrew Cooper", Title = "Software architecture", Genre = Genre.SoftwareArchitecture, NumberOfPages = 380, Price = 185 });
			_testBooks.Add(new Book() { Id = 5, Author = "Susan Williams", Title = "SOLID principles", Genre = Genre.SoftwareArchitecture, NumberOfPages = 410, Price = 190 });
		}

		public Book GetBy(int id)
		{
			return (from b in _testBooks where b.Id == id select b).FirstOrDefault();
		}

		public IEnumerable<Book> GetAll()
		{
			return _testBooks;
		}

		public void AddNew(Book book)
		{
			book.Id = _testBooks.Count + 1;
			_testBooks.Add(book);
		}

		public void CommitChanges()
		{
			
		}
	}
}
