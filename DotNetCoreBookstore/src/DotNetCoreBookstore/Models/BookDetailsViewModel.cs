namespace DotNetCoreBookstore.Models
{
	public class BookDetailsViewModel : BookViewModel
    {
		public int NumberOfPages { get; set; }
		public decimal Price { get; set; }
		public string Genre { get; set; }
	}
}
