using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZetsubouGacha.Databases;
using ZetsubouGacha.Servants.Models;

namespace ZetsubouGacha.Servants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServantController : ControllerBase
    {
        private readonly IServantRepository servantRepository;

        public ServantController(IDbContext dbContext)
        {
            this.servantRepository = dbContext.Servants;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servant>> ServantById(int id)
        {
            Servant servant = await servantRepository.GetServantByIdAsync(id);
            if (servant == null)
            {
                return NotFound();
            }
            return servant;
        }
    }
}