using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZetsubouGacha.Models
{
    public interface IZetsubouGachaDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ServantsCollectionName { get; set; }
    }

    public class ZetsubouGachaDatabaseSettings : IZetsubouGachaDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string ServantsCollectionName { get; set; }
    }
}
