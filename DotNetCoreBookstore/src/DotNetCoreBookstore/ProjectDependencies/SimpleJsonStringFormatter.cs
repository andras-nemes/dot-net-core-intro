using DotNetCoreBookstore.Dependencies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.ProjectDependencies
{
	public class SimpleJsonStringFormatter : IStringFormatter
	{
		public string FormatMe(object input)
		{
			return JsonConvert.SerializeObject(input);
		}
	}
}
