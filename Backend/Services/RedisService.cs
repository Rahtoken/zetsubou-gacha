using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using ZetsubouGacha.Settings;

namespace ZetsubouGacha.Services
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _redis;

        public RedisService(RedisSettings redisSettings)
        {
            _host = redisSettings.Host;
            _port = int.Parse(redisSettings.Port);
        }

        public void Connect()
        {
            try
            {
                string configuration = $"{_host}:{_port}";
                _redis = ConnectionMultiplexer.Connect(configuration);
            }
            catch (RedisConnectionException err)
            {
                throw err;
            }
        }

        public async Task PutAsync(string key, string value)
        {
            var db = _redis.GetDatabase();
            await db.StringSetAsync(key, value);
        }

        public async Task<(bool success, string result)> GetAsync(string key)
        {
            var db = _redis.GetDatabase();
            var result = await db.StringGetAsync(key);
            return (result.HasValue, result);
        }

        public static string Serialize<T>(T obj) => JsonSerializer.Serialize(obj);

        public static T Deserialize<T>(string serializedOject) => JsonSerializer.Deserialize<T>(serializedOject);

    }
}
