using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotNetCoreBookstore.TagHelpers
{
	//[HtmlTargetElement("home", TagStructure = TagStructure.WithoutEndTag)]
    public class HomeTagHelper : TagHelper
    {
		public string BookstoreHomeAddress { get; set; }
		public string BookstoreHomeLinkContent { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";
			string cont = output.Content.GetContent();	    
			output.Attributes.SetAttribute("href", BookstoreHomeAddress);
			output.Content.SetContent(BookstoreHomeLinkContent);
		}
	}
}
