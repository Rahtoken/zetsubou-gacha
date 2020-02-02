using System;
using MongoDB.Driver;

namespace ZetsubouGacha.Servants.Models
{
    public interface IMongoDatabaseFactory
    {
        IMongoDatabase Connect(string connectionString, string databaseName);  
    }
}
