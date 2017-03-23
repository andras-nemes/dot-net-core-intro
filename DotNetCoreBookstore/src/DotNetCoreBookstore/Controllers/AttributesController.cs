using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreBookstore.Controllers
{
	//[Route("mickeymouse")]
	//[Route("[controller]/[action]")]
	[Route("mickeymouse")]
	[Route("pluto")]
	[Route("looneytunes")]
	public class AttributesController : Controller
	{        
		//[Route("donaldduck")]
		[HttpGet("donaldduck")]
		public string Index()
		{
			return "Hello from the Index action method of the Attributes controller.";
		}
	}
}
