using DotNetCoreBookstore.Domains;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreBookstore.Models
{
	public class InsertBookViewModel
	{
		[Display(Prompt = "Enter title")]
		[Required(ErrorMessage = "The title is required"), MaxLength(10, ErrorMessage = "A book title cannot exceed 10 characters")]
		[DataType(DataType.Text)]
		public string Title { get; set; }
		[Required(ErrorMessage = "The author is required"), MaxLength(15, ErrorMessage = "A book author cannot exceed 15 characters")]
		public string Author { get; set; }
		[Display(Name = "Number of pages")]
		[Required(ErrorMessage = "Number of pages is required"), Range(1, 10000, ErrorMessage = "Min pages: 1, max pages: 10000")]
		public int NumberOfPages { get; set; }
		[Required(ErrorMessage = "Enter a price"), Range(1, 1000, ErrorMessage = "Min price: 1, max price: 1000")]
		[Display(Name = "Price in USD")]
		public decimal Price { get; set; }
		public Genre Genre { get; set; }
	}
}
