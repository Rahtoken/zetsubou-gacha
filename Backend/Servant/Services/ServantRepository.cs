using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Servants.Services
{
    public class ServantRepository : IServantRepository
    {
        private readonly IMongoCollection<Servant> servants;

        public ServantRepository(IMongoCollection<Servant> servantsCollection)
        {
            servants = servantsCollection;
        }

        public async Task<IEnumerable<Servant>> GetAllServantsAsync(int limit)
        {
            var findOptions = new FindOptions<Servant>()
            {
                Limit = limit
            };
            using var findResult = await servants.FindAsync(servant => true, findOptions);
            return await findResult.ToListAsync();
        }

        public async Task<Servant> GetServantByIdAsync(int id)
        {
            using var findResult = await servants.FindAsync(servant => servant.Id == id);
            return await findResult.FirstOrDefaultAsync();
        }
    }
}