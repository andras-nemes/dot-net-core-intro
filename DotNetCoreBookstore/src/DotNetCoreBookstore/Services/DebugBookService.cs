using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreBookstore.Domains;
using DotNetCoreBookstore.Repositories;

namespace DotNetCoreBookstore.Services
{
	public class DebugBookService : IBookService
	{
		private readonly IBookRepository _bookRepository;

		public DebugBookService(IBookRepository bookRepository)
		{
			if (bookRepository == null) throw new ArgumentNullException("Book repository");
			_bookRepository = bookRepository;
		}

		public void AddNew(Book book)
		{
			try
			{
				_bookRepository.AddNew(book);
				_bookRepository.CommitChanges();			
			}
			catch
			{
				throw;
			}
		}

		public IEnumerable<Book> GetAll()
		{
			try
			{
				return _bookRepository.GetAll();
			}
			catch
			{
				throw;
			}
		}

		public Book GetBy(int id)
		{
			try
			{
				return _bookRepository.GetBy(id);
			}
			catch
			{
				throw;
			}
		}
	}
}
