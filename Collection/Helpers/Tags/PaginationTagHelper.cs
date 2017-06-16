using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Helpers.Tags
{
    [HtmlTargetElement("pagination")]
    public class PaginationTagHelper : TagHelper
    {
        [HtmlAttributeName("pg-current-page")]
        public int CurrentPage { get; set; } = 1;

        [HtmlAttributeName("pg-total-pages")]
        public int TotalPages { get; set; } = 1;

        public string btnClass = "pg-btn";

        public int btnRange = 3;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var attr = context.AllAttributes.Where(x => x.Name.Contains("asp")).ToList();

            var uriParams = attr.Where(x => x.Name.Contains("asp-route-"))
                                .Where(x => x.Name.ToLower() != "asp-route-page")
                                .Where(x => x.Value as String != "")
                                .Select(x => x.Name.Replace("asp-route-", "") + "=" + x.Value).ToList();

            var controller = attr.Find(x => x.Name == "asp-controller")?.Value.ToString() ?? String.Empty;
            var action = attr.Find(x => x.Name == "asp-action")?.Value.ToString() ?? String.Empty;

            var uri = "/";

            if (!String.IsNullOrEmpty(controller))
                uri += controller;

            if (!String.IsNullOrEmpty(action))
                uri += "/" + action;

            uri += "?" + String.Join("&", uriParams);
            uri += "&page=";

            if (TotalPages <= 0)
                TotalPages = 1;

            if (CurrentPage <= 0)
                CurrentPage = 1;

            if (CurrentPage > TotalPages)
                CurrentPage = TotalPages;

            //if (TotalPages <= 0)
            //    throw new ArgumentException($"'TotalPages' must be greater then 0. Current value is {TotalPages}.");

            //if (CurrentPage <= 0)
            //    throw new ArgumentException($"'CurrentPage' must be greater then 0. Current value is {CurrentPage}.");

            //if (CurrentPage > TotalPages)
            //    throw new ArgumentException($"'CurrentPage' must be within the range of 1 and {TotalPages}. Current value is {CurrentPage}.");

            output.TagName = "div";

            var activeBtnStyle = btnClass + " pg-active";

            if (CurrentPage == 1)
            {
                output.Content.AppendHtml(CreateButton("1", activeBtnStyle, uri + "1"));
            }
            else
            {
                output.Content.AppendHtml(CreateButton("Prev", btnClass, uri + (CurrentPage - 1)));
                output.Content.AppendHtml(CreateButton("1", btnClass, uri + "1"));
            }

            var minRange = CurrentPage - btnRange;
            var maxRange = CurrentPage + btnRange;

            if (minRange <= 1)
                minRange = 2;

            if (maxRange >= TotalPages)
                maxRange = TotalPages - 1;

            if (minRange > 2)
            {
                output.Content.AppendHtml(CreateDots(btnClass));
            }

            for (int i = minRange; i <= maxRange; i++)
            {
                output.Content.AppendHtml(CreateButton($"{i}", i == CurrentPage ? activeBtnStyle : btnClass, uri + i));
            }

            if (TotalPages - maxRange > 1)
            {
                output.Content.AppendHtml(CreateDots(btnClass));
            }

            if (TotalPages > 1)
            {
                if (CurrentPage == TotalPages)
                {
                    output.Content.AppendHtml(CreateButton($"{TotalPages}", activeBtnStyle, uri + TotalPages));
                }
                else
                {
                    output.Content.AppendHtml(CreateButton($"{TotalPages}", btnClass, uri + TotalPages));
                    output.Content.AppendHtml(CreateButton("Next", btnClass, uri + (CurrentPage + 1)));
                }
            }

            base.Process(context, output);
        }

        private TagBuilder CreateButton(string innerText, string style, string href)
        {
            TagBuilder anchor = new TagBuilder("a");

            anchor.AddCssClass(style);
            anchor.InnerHtml.Append(innerText);
            anchor.Attributes.Add("href", href);

            return anchor;
        }

        private TagBuilder CreateDots(string style)
        {
            TagBuilder dots = new TagBuilder("span");
            dots.AddCssClass(style);
            dots.InnerHtml.Append("...");
            return dots;
        }

    }
}
