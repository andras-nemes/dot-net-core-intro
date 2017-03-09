using DotNetCoreBookstore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Repositories
{
	public interface IBookRepository : ICommittableRepository
	{
		IEnumerable<Book> GetAll();
		Book GetBy(int id);
		void AddNew(Book book);
	}
}
