using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreBookstore.Domains;

namespace DotNetCoreBookstore.Repositories
{
	public class BookStoreRepository : IBookRepository
	{
		private readonly BookStoreDbContext _bookStoreDbContext;

		public BookStoreRepository(BookStoreDbContext bookStoreDbContext)
		{
			if (bookStoreDbContext == null) throw new ArgumentNullException("Book store DB context");
			_bookStoreDbContext = bookStoreDbContext;
		}

		public void AddNew(Book book)
		{
			_bookStoreDbContext.Books.Add(book);
		}

		public void CommitChanges()
		{
			_bookStoreDbContext.SaveChanges();
		}

		public IEnumerable<Book> GetAll()
		{
			return _bookStoreDbContext.Books;
		}

		public Book GetBy(int id)
		{
			return (from b in _bookStoreDbContext.Books where b.Id == id select b).FirstOrDefault();
		}
	}
}
