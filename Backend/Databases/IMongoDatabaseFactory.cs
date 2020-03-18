using MongoDB.Driver;

namespace ZetsubouGacha.Databases
{
    public interface IMongoDatabaseFactory
    {
        IMongoDatabase Connect(string connectionString, string databaseName);
    }
}
