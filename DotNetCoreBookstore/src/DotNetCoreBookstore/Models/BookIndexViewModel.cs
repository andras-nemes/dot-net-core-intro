using System.Collections.Generic;

namespace DotNetCoreBookstore.Models
{
	public class BookIndexViewModel
    {
		public IEnumerable<BookViewModel> BookViewModels { get; set; }
		public int TotalBooksOnOffer { get; set; }
	}
}
