using System;

namespace ZetsubouGacha.Servants.Models
{
    public interface IRepositoryFactory
    {
        IServantRepository Create(IRepositoryOptions repositoryOptions);
    }
}
