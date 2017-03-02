using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.TagHelpers
{
	[HtmlTargetElement(Attributes = nameof(TooLongDidntRead))]
	public class TooLongDidntReadTagHelper : TagHelper
    { 
		public bool TooLongDidntRead { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (TooLongDidntRead)
			{
				output.SuppressOutput();
			}
		}
	}
}
