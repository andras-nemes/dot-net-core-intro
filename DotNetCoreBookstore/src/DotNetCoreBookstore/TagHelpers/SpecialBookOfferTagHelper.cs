using DotNetCoreBookstore.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotNetCoreBookstore.TagHelpers
{
	[HtmlTargetElement("book-on-offer")]
	public class SpecialBookOfferTagHelper : TagHelper
	{
		public BookViewModel Book { get; set; }
		public decimal SpecialPrice { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "section";
			output.Content.SetHtmlContent(
				$@"<h1>Special offer!</h1><br /> 
				<ul>
					<li>Title: {Book.Title}</li>
					<li>Author: {Book.Author}</li>
					<li>Price: {SpecialPrice}</li>
				</ul>");
		}
	}
}

