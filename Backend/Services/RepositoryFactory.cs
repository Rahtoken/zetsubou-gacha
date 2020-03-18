using ZetsubouGacha.Databases;
using ZetsubouGacha.Servants.Models;
using ZetsubouGacha.Servants.Services;

namespace ZetsubouGacha.Services
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IMongoDatabaseFactory databaseFactory;

        public RepositoryFactory(IMongoDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        public IServantRepository Create(IRepositoryOptions repositoryOptions)
        {
            var database = databaseFactory.Connect(repositoryOptions.ConnectionString, repositoryOptions.DatabaseName);
            return new ServantRepository(database.GetCollection<Servant>(repositoryOptions.CollectionName));
        }
    }
}