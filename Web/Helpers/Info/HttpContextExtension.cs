using System;
using Microsoft.AspNetCore.Http;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;

namespace Pnprpg.WebCore.Helpers
{
    public static class HttpContextExtension
    {
        public static MajorType GetMajor(this HttpContext context)
        {
            context.Request.Query.TryGetValue(Constants.Major, out var prefix);
            if (!int.TryParse(prefix, out var major) || !Enum.IsDefined(typeof(MajorType), major))
                return MajorType.Common;
            return (MajorType) major;
        }
    }
}
