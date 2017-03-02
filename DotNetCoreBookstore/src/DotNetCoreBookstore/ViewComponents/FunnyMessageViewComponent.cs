using DotNetCoreBookstore.Dependencies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.ViewComponents
{
    public class FunnyMessageViewComponent : ViewComponent
    {
		private readonly IStringFormatter _stringFormatter;

		public FunnyMessageViewComponent(IStringFormatter stringFormatter)
		{
			if (stringFormatter == null) throw new ArgumentNullException("String formatter!");
			_stringFormatter = stringFormatter;
		}

		public IViewComponentResult Invoke(object objectToFormat)
		{
			return View("Show", _stringFormatter.FormatMe(objectToFormat));
		}
	}
}
