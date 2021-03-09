using System;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;

namespace Pnprpg.WebCore.Helpers
{
    public static class UrlExtensions
    {
        public static string CustomPage(this IUrlHelper urlHelper, string pageName, object values) =>
            urlHelper.ComposeUrl(pageName, null, values);

        public static string CustomPage(this IUrlHelper urlHelper, string pageName, string pageHandler = null, object values = null, string protocol = null) =>
            urlHelper.ComposeUrl(pageName, pageHandler, values, protocol);

        private static string ComposeUrl(this IUrlHelper urlHelper, string pageName, string pageHandler = null, object values = null, string protocol = null)
        {
            var url = urlHelper.Page(pageName, pageHandler, values, protocol);
            if (!pageName.Contains(Constants.Major, StringComparison.OrdinalIgnoreCase))
                return url;

            var prefix = urlHelper.ActionContext.HttpContext.GetMajor();
            url = prefix == MajorType.Common ? "/" : 
                url.Replace(Constants.Major, prefix.Description(), StringComparison.OrdinalIgnoreCase);
            return url;
        }
    }
}
