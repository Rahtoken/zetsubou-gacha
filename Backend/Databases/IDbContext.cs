using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Databases
{
    public interface IDbContext
    {
        IServantRepository Servants { get; }
    }
}
