using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperEx.TagHelpers
{
    [HtmlTargetElement("hc-combo-item")]
    public class ComboItemTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ((ComboTagHelper)context.Items[typeof(ComboTagHelper)]).ComboItem = this;
            output.SuppressOutput();
        }
    }
}
