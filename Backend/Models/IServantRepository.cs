using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZetsubouGacha.Models
{
    public interface IServantRepository
    {
        Task<Servant> GetServantByIdAsync(int id);
        Task<IEnumerable<Servant>> GetAllServantsAsync(int limit);
    }
}