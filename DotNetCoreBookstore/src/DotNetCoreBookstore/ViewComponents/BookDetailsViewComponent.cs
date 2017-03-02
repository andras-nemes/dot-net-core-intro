using DotNetCoreBookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.ViewComponents
{
    public class BookDetailsViewComponent : ViewComponent
    {
		public IViewComponentResult Invoke(BookDetailsViewModel bookDetailsViewModel)
		{
			return View("Details", bookDetailsViewModel);
		}
    }
}
