using ZetsubouGacha.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

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

        public async Task<List<Servant>> GetAllServantsAsync()
        {
            var findResult = await _servants.FindAsync(servant => true);
            var servantResults = await findResult.ToListAsync();
            return servantResults;
        }

        public async Task<Servant> GetServantAsync(int id)
        {
            var findResult = await _servants.FindAsync(servant => servant.Id == id);
            var servantResult = await findResult.FirstOrDefaultAsync();
            return servantResult;
        }
    }
}
