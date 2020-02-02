using System;
using MongoDB;
using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Servants.Services
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
            return (IServantRepository) new ServantRepository(database.GetCollection<Servant>(repositoryOptions.CollectionName));
        }
    }
}
