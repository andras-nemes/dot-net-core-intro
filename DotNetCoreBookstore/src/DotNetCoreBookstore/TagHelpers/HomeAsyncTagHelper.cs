using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.TagHelpers
{
    public class HomeAsyncTagHelper : TagHelper
    {
		public string BookstoreHomeAddress { get; set; }
		public string BookstoreHomeLinkContent { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";
			TagHelperContent content = await output.GetChildContentAsync();
			string cont = content.GetContent();
			output.Attributes.SetAttribute("href", BookstoreHomeAddress);
			output.Attributes.SetAttribute("greeting", content);
			output.Content.SetContent(BookstoreHomeLinkContent);
		}
	}
}
