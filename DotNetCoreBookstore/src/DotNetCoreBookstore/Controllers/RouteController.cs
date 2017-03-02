using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreBookstore.Controllers
{
    public class RouteController : Controller
    {
		public string Index()
		{
			return "Hello from the Index action method of the Route controller"; 
		}

		public string Activity(string whatever)
		{

			return "This is the activity action method in the Route controller. Your activity: " + whatever;
		}
    }
}
