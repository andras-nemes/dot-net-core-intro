using DotNetCoreBookstore.Domains;
using System.Collections.Generic;

namespace DotNetCoreBookstore.Services
{
	public interface IBookService
    {
		IEnumerable<Book> GetAll();
		Book GetBy(int id);
		void AddNew(Book book);
    }
}
