using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Middleware
{
    public class MajorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMajorService _majorService;
        private readonly IDistributedCache _cache;

        public MajorsMiddleware(RequestDelegate next, IMajorService majorService, IDistributedCache cache)
        {
            _next = next;
            _majorService = majorService;
            _cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            AddMajorPrefix(context);
            await _next(context);
        }

        private void AddMajorPrefix(HttpContext context)
        {
            var major = GetMajorFromUrl(context.Request.Path);
            if (major == MajorType.Common) 
                return;

            context.Request.Path = context.Request.Path.Value.ToLower().Replace(major.Description(), Constants.Major);
            context.Request.QueryString = context.Request.QueryString.Add(Constants.Major, $"{(int)major}");
            context.SaveCookie(CookieType.Major, ((int)major).ToString(), 1);
            context.Items.Add("Color", GetColorFromCache((int)major));
        }

        private MajorType GetMajorFromUrl(string src)
        {
            var firstArea = src.Trim('/').Split('/').First();
            return string.IsNullOrEmpty(firstArea) ? MajorType.Common : GetMajorFromDesc(firstArea);
        }

        private MajorType GetMajorFromDesc(string src)
        {
            var list = Enum.GetValues(typeof(MajorType)).Cast<MajorType>();
            return list.FirstOrDefault(major => src.Equals(major.Description(), StringComparison.OrdinalIgnoreCase));
        }

        private string GetColorFromCache(int majorId)
        {
            var key = $"major-color-{majorId}";
            var color = CacheHelper.GetFromCache<string>(key, _cache);
            if (!string.IsNullOrEmpty(color))
                return color;

            color = $"#{_majorService.GetShortModel(majorId).Color}";
            CacheHelper.SetInCacheSliding(key, color, _cache);
            return color;
        }
    }
}
