using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Middleware
{
    public class LoggerComponent
    {
		private readonly RequestDelegate _next;
		private readonly string _username;
		private readonly DateTime _when;

		public LoggerComponent(RequestDelegate next, string username, DateTime when)
		{
			_next = next;
			_username = username;
			_when = when;
		}

		public async Task Invoke(HttpContext context)
		{

			Debug.WriteLine($"Hello from the logger component: {_username}, {_when}");
			await _next(context);			
		}		
	}
}
