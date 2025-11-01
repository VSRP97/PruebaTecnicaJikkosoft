using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Application.Abstractions.Caching;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace LibraryManager.Infrastructure.Caching
{
    internal sealed class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            byte[]? bytes = _cache.Get<byte[]>(key);

            return Task.FromResult(bytes is null ? default : Deserialize<T>(bytes));
        }

        public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            _cache.Remove(key);
            return Task.CompletedTask;
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            byte[] bytes = Serialize(value);

            _cache.Set(key, bytes, CacheOptions.Create(expiration));

            return Task.CompletedTask;
        }

        private byte[] Serialize<T>(T? value)
        {
            var jsonData = JsonConvert.SerializeObject(value);

            return Encoding.UTF8.GetBytes(jsonData);
        }

        private T Deserialize<T>(byte[] bytes)
        {
            string jsonData = Encoding.UTF8.GetString(bytes);

            return JsonConvert.DeserializeObject<T>(jsonData)!;
        }

    }
}
