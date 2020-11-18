using System;
using Microsoft.AspNetCore.Html;

namespace Pnprpg.WebCore.Helpers
{
    public class PartialHelper
    {
        public static IHtmlContent Body(Func<object, IHtmlContent> body) => body(null);
    }
}