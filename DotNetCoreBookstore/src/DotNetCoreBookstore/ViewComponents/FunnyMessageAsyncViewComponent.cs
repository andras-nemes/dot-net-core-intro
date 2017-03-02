using DotNetCoreBookstore.Dependencies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.ViewComponents
{
    public class FunnyMessageAsyncViewComponent : ViewComponent
    {
		private readonly IStringFormatter _stringFormatter;

		public FunnyMessageAsyncViewComponent(IStringFormatter stringFormatter)
		{
			if (stringFormatter == null) throw new ArgumentNullException("String formatter!");
			_stringFormatter = stringFormatter;
		}

		public async Task<IViewComponentResult> InvokeAsync(object objectToFormat)
		{
			string formatted = await Task.Factory.StartNew(() => { return _stringFormatter.FormatMe(objectToFormat); });
			return View("Show", formatted);
		}

	}
}
