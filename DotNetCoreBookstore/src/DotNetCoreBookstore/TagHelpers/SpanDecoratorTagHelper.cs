using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.TagHelpers
{
	[HtmlTargetElement(Attributes = "spandec")]
	public class SpanDecoratorTagHelper : TagHelper
    {
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			TagHelperContent content = await output.GetChildContentAsync();
			string spandecAttrValue = output.Attributes["spandec"].Value.ToString();
			string textContent = content.GetContent();
			output.Attributes.RemoveAll("spandec");
			output.PreContent.SetHtmlContent($"<span class=\"{spandecAttrValue}\">");
			output.PostContent.SetHtmlContent("</span>");
			output.Content.SetContent(textContent);
		}
	}
}
