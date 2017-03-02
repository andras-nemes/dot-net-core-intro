using DotNetCoreBookstore.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore
{
    public static class MiddlewareRegistrationExtension
    {
		public static IApplicationBuilder UseLoggerComponent(this IApplicationBuilder builder, string username, DateTime when)
		{
			return builder.UseMiddleware<LoggerComponent>(username, when);
		}

		public static IApplicationBuilder UseEndOfTheWorldComponent(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<EndOfTheWorldComponent>();
		}
	}
}
