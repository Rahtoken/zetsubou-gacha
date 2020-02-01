using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZetsubouGacha.Servants.Models;
using ZetsubouGacha.Servants.Settings;

namespace ZetsubouGacha.Servants.Services
{
    public class ServantService : IServantRepository
    {
        private readonly IMongoCollection<Servant> _servants;
        public ServantService(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _servants = database.GetCollection<Servant>(settings.ServantsCollection);
        }

        public async Task<IEnumerable<Servant>> GetAllServantsAsync(int limit)
        {
            var findOptions = new FindOptions<Servant>()
            {
                Limit = limit
            };
            using var findResult = await _servants.FindAsync(servant => true, findOptions);
            return await findResult.ToListAsync();
        }

        public async Task<Servant> GetServantByIdAsync(int id)
        {
            using var findResult = await _servants.FindAsync(servant => servant.Id == id);
            return await findResult.FirstOrDefaultAsync();
        }
    }
}
