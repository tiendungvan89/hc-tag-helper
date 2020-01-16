using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Json;

namespace TagHelperEx.TagHelpers
{
    [HtmlTargetElement("hc-combo")]
    public class ComboTagHelper : TagHelper
    {
        [HtmlAttributeName("hc-key")]
        public string Key { get; set; }

        [HtmlAttributeName("hc-value")]
        public object Value { get; set; }

        [HtmlAttributeName("hc-data-source")]
        public ICollection<ComboItem> DataSource { get; set; }

        [HtmlAttributeName("hc-model-for")]
        public ModelExpression ModelFor { get; set; }

        public ComboItemTagHelper ComboItem { get; set; }

        public async override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items.Add(typeof(ComboTagHelper), this);
            await output.GetChildContentAsync();

            output.TagName = "select";

            if (DataSource == null || DataSource.Count == 0)
            {
                output.SuppressOutput();
                return;
            }

            //string selected = ModelFor.Model as string; //TODO: Use later

            foreach (var item in DataSource)
            {
                var tagJson = JsonSerializer.Serialize<ComboItem>(item);
                output.Content.AppendHtml($"<option value='{item.Key}' data-item='{tagJson}'>{item.Value}</option>");
            }

            //output.Attributes.SetAttribute("Name", ModelFor.Name);
            //output.Attributes.SetAttribute("Id", ModelFor.Name);
        }
    }
}
