using ZetsubouGacha.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System;

namespace ZetsubouGacha.Services
{
    public class ServantService
    {
        private readonly IMongoCollection<Servant> _servants;

        public ServantService(IZetsubouGachaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _servants = database.GetCollection<Servant>(settings.ServantsCollectionName);
        }

        public List<Servant> Get() => _servants.Find(servant => true).ToList();
    }
}
