using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
	[HtmlTargetElement("table")]
	public class TableTagHelper : TagHelper
	{
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			//Sınıf içerisinde tanımlanan tablolara
			//bootstrapin table özelliğini ekledik
			output.Attributes.SetAttribute("class", "table table-hover");
		}
	}
}
