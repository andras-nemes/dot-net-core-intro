using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreBookstore.Models;
using DotNetCoreBookstore.Services;
using DotNetCoreBookstore.Domains;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreBookstore.Controllers
{
	[Authorize]
    public class BooksController : Controller
    {
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			if (bookService == null) throw new ArgumentNullException("Book service!");
			_bookService = bookService;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			Debug.WriteLine(string.Concat("User is authenticated: ", User.Identity.IsAuthenticated));
			Debug.WriteLine(string.Concat("User is an admin: ", User.IsInRole("Administrators")));
			Debug.WriteLine(string.Concat("User claims: ", string.Join("|", (from c in User.Claims select string.Concat("Key: ", c.Type, ", value: ", c.Value)))));
			return View(GetBookIndexViewModel());
		}

		public IActionResult Details(int id)
		{
			BookDetailsViewModel bookDetailsViewModel = new BookDetailsViewModel();
			var book = _bookService.GetBy(id);
			if (book != null)
			{
				bookDetailsViewModel.Author = book.Author;
				bookDetailsViewModel.Genre = book.Genre.ToString();
				bookDetailsViewModel.Id = book.Id;
				bookDetailsViewModel.NumberOfPages = book.NumberOfPages;
				bookDetailsViewModel.Price = book.Price;
				bookDetailsViewModel.Title = book.Title;
			}
			else
			{
				string na = "N/A";
				bookDetailsViewModel.Author = na;
				bookDetailsViewModel.Genre = na;
				bookDetailsViewModel.Id = -1;
				bookDetailsViewModel.NumberOfPages = 0;
				bookDetailsViewModel.Price = 0;
				bookDetailsViewModel.Title = na;
			}
			return View(bookDetailsViewModel);
		}

		[HttpGet]
		public IActionResult Create()
		{
			InsertBookViewModel insertBookViewModel = new InsertBookViewModel();
			return View(insertBookViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(InsertBookViewModel insertBookViewModel)
		{
			if (ModelState.IsValid)
			{
				Book newBook = new Book()
				{
					Author = insertBookViewModel.Author,
					Genre = insertBookViewModel.Genre,
					NumberOfPages = insertBookViewModel.NumberOfPages,
					Price = insertBookViewModel.Price,
					Title = insertBookViewModel.Title
				};
				_bookService.AddNew(newBook);
				return RedirectToAction("Index");
			}

			return View();
		}

		private IEnumerable<BookViewModel> GetBooks()
		{
			var books = _bookService.GetAll();
			return (from b in books select new BookViewModel() { Id = b.Id, Author = b.Author, Title = b.Title });			
		}

		private BookIndexViewModel GetBookIndexViewModel()
		{
			BookIndexViewModel bookIndexViewModel = new BookIndexViewModel();
			var bookViewModels = GetBooks();
			bookIndexViewModel.BookViewModels = bookViewModels;
			bookIndexViewModel.TotalBooksOnOffer = bookViewModels.Count();
			return bookIndexViewModel;
		}
	}
}
