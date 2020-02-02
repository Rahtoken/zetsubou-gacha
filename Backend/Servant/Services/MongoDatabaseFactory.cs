using System;
using MongoDB.Driver;
using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Servants.Services
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
