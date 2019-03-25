using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.Helpers
{
    public class CacheProvider
    {
        private IMemoryCache memoryCache;
        public CacheProvider(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public T GetAndSave<T>(Func< string> keyGetter, Func<T> objGet) 
        {
            string memoryCacheKey = keyGetter();
            T result;
            if (!memoryCache.TryGetValue(memoryCacheKey, out result))
            {
                result = objGet();
         
                memoryCache.Set(memoryCacheKey, result);
            }
            return result; 
        }
    }
}
