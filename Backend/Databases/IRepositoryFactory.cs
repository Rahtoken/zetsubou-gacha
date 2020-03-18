using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Databases
{
    public interface IRepositoryFactory
    {
        IServantRepository Create(IRepositoryOptions repositoryOptions);
    }
}
