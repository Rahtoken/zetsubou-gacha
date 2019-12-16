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

        //public async Task<(bool success, Servant servant)> TryGetServantCachedAsync(int servantId)
        //{
        //    var db = _redis.GetDatabase();
        //    string a = db.StringSet(servantId, JsonSerializer.Ser)
        //    //var cachedSerant = await db.StringGetAsync(servantId.ToString());
        //}
    }
}
