using System;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public class IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> GetCachedResponseAsync(string cacheKey);
        
    }
}