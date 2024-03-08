using HepsiApiProject.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _database;
        private readonly RedisCacheSettigs _settings;

        public RedisCacheService(IOptions<RedisCacheSettigs> options)
        {
            _settings = options.Value;
            var opt = ConfigurationOptions.Parse(_settings.ConnectionString);
            _redisConnection = ConnectionMultiplexer.Connect(opt);
            _database = _redisConnection.GetDatabase();
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.HasValue)
                return JsonConvert.DeserializeObject<T>(value);

            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            var timeUntilExpiration = expirationTime.Value - DateTime.Now;
            await _database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUntilExpiration);
        }
    }
}
