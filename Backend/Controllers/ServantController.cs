using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZetsubouGacha.Models;
using ZetsubouGacha.Services;

namespace ZetsubouGacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServantController : ControllerBase
    {
        private readonly IServantRepository servantRepository;

        private readonly RedisService redis;

        public ServantController(IServantRepository servantRepository, RedisService redis)
        {
            this.servantRepository = servantRepository;
            this.redis = redis;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servant>>> AllServants(int limit)
        {
            if (limit < 0)
            {
                return BadRequest();
            }
            return (await servantRepository.GetAllServantsAsync(limit)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servant>> ServantById(int id)
        {
<<<<<<< HEAD
            Servant servant = await servantRepository.GetServantByIdAsync(id);
=======
            var cachedResult = await redis.GetAsync(id.ToString());
            Servant servant = cachedResult.success switch
            {
                true => RedisService.Deserialize<Servant>(cachedResult.result),
                false => await servantRepository.GetServantByIdAsync(id)
            };
            if (!cachedResult.success)
            {
                var toCache = RedisService.Serialize(servant);
                await redis.PutAsync(id.ToString(), toCache);
            }
>>>>>>> master
            if (servant == null)
            {
                return NotFound();
            }
            return servant;
        }
    }
}
