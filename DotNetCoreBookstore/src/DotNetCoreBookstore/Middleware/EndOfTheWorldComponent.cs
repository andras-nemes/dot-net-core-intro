using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Middleware
{
    public class EndOfTheWorldComponent
    {
		public EndOfTheWorldComponent(RequestDelegate next)
		{}

		public async Task Invoke(HttpContext context)
		{		
			await context.Response.WriteAsync("This ís the end of the world...");
		}

	}
}
