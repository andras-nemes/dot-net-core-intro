using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.TagHelpers
{
	[HtmlTargetElement(Attributes = "if")]
	public class IfTagHelper : TagHelper
	{
		public bool If { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (!If)
			{
				output.SuppressOutput();
			}
		}
	}
}
