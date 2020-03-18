using ZetsubouGacha.Databases;
using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Services
{
    public class DbContext : IDbContext
    {
        public DbContext(IRepositoryFactory repositoryFactory, string connectionString, string dbName)
        {
            Servants = repositoryFactory.Create(new RepositoryOptions(connectionString, dbName, "Servants"));
        }

        public IServantRepository Servants { get; private set; }
    }
}
