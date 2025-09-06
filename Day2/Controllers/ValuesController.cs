using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration = 20)]
        public List<string> Get()
        {
            return new List<string>() { "Mumbai", "Delhi", "Chennai" };
        }

        [HttpGet("memory")]
        public string GetTime(IMemoryCache memoryCache)
        {
            // get from memory cache if exists
            memoryCache.TryGetValue("time", out string time);

            if (string.IsNullOrEmpty(time))
            {
                time = DateTime.Now.ToString();


                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSize(30)
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10))
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5));

                memoryCache.Set("time", time, cacheOptions);
            }
            return time;

        }
    }
}
