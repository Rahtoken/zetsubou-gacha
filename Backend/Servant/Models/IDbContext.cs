using System;

namespace ZetsubouGacha.Servants.Models
{
    public interface IDbContext
    {
        IServantRepository Servants { get; }
    }
}
