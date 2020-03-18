namespace ZetsubouGacha.Settings
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        string ServantsCollection { get; set; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
        public string ServantsCollection { get; set; }
    }
}