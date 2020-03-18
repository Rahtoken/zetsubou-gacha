using MongoDB.Driver;
using ZetsubouGacha.Databases;

namespace ZetsubouGacha.Services
{
    public class MongoDatabaseFactory : IMongoDatabaseFactory
    {

        public IMongoDatabase Connect(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            return client.GetDatabase(databaseName);
        }
    }
}
