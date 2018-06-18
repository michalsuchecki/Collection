using System;
using Microsoft.AspNetCore.Http;

namespace Collection.Extensions
{
    public static class HttpContextExtensions
    {
        public static string UrlReferer(this HttpContext context)
        {
            var referer = String.Empty;

            if(context.Request.Headers.ContainsKey("Referer"))
                referer = context.Request.Headers["Referer"];

            return referer;
        }
    }
}