using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopPizzaHut.Helper
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, string height)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src",src);
            builder.MergeAttribute("alt",altText);
            builder.MergeAttribute("height",height);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}