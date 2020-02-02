using System;
using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Servants.Services
{
    public class DbContext : IDbContext
    {
        public DbContext(IRepositoryFactory repositoryFactory, string connectionString, string dbName)
        {
            this.Servants = repositoryFactory.Create(new RepositoryOptions(connectionString, dbName, "Servants"));
        }

        public IServantRepository Servants { get; private set; }
    }
}
