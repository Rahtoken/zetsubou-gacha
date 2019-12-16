namespace ZetsubouGacha.Settings
{
    public class RedisSettings : IRedisSettings
    {
        public string Host { get ; set ; }
        public string Port { get ; set ; }
    }

    public interface IRedisSettings
    {
        string Host { get; set; }
        string Port { get; set; }
    }
}