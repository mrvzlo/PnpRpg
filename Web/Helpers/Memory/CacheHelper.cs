using System;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Pnprpg.WebCore.Helpers
{
    public static class CacheHelper
    {
        private const double DefaultAbsoluteMinutes = 5;
        private const double DefaultSlidingMinutes = 2;

        public static T GetFromCache<T>(string cacheKey, IDistributedCache cache)
        {
            var cachedObj = cache.Get(cacheKey.ToUpper());
            return cachedObj == null ? default : BytesToObject<T>(cachedObj);
        }

        public static void SetInCacheSliding(string cacheKey, object obj, IDistributedCache cache, double minutes = DefaultSlidingMinutes)
        {
            SetInCache(cacheKey, obj, cache, null, minutes);
        }

        private static void SetInCache(string cacheKey, object obj, IDistributedCache cache, double? absoluteMinutes, double? slidingMinutes)
        {
            var byteArray = ObjectToBytes(obj);
            if (byteArray == null) 
                return;

            var options = new DistributedCacheEntryOptions();
            if (slidingMinutes.HasValue) 
                options.SetSlidingExpiration(TimeSpan.FromMinutes(slidingMinutes.Value));
            if (absoluteMinutes.HasValue) 
                options.SetAbsoluteExpiration(TimeSpan.FromMinutes(absoluteMinutes.Value));
            cache.Set(cacheKey.ToUpper(), byteArray, options);
        }

        private static byte[] ObjectToBytes(object obj)
        {
            var str = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(str);
        }

        private static T BytesToObject<T>(byte[] arr)
        {
            var str = Encoding.UTF8.GetString(arr);
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
