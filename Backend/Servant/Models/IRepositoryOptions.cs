using System;

namespace ZetsubouGacha.Servants.Models
{
    public interface IRepositoryOptions
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string CollectionName { get; set; }
    }
}
