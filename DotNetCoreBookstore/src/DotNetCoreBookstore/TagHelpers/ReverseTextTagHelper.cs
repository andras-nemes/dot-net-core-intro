using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.TagHelpers
{
	[HtmlTargetElement("reverse")]
	[HtmlTargetElement(Attributes = "reverse")]
	public class ReverseTextTagHelper : TagHelper
    {
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			output.Attributes.RemoveAll("reverse");
			TagHelperContent content = await output.GetChildContentAsync();
			char[] charArray = content.GetContent().ToCharArray();
			Array.Reverse(charArray);
			output.Content.SetContent(new string(charArray));			
		}
	}
}
