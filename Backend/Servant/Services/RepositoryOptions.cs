using System;
using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Servants.Services
{
    public class RepositoryOptions: IRepositoryOptions
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }

        public RepositoryOptions(string connectionString, string databaseName, string collectionName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
            CollectionName = collectionName;
        }
    }
}
