using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZetsubouGacha.Models;
using ZetsubouGacha.Services;

namespace ZetsubouGacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServantController: ControllerBase
    {
        private readonly ServantService _servantService;

        public ServantController(ServantService servantService)
        {
            _servantService = servantService;
        }

        [HttpGet]
        public async Task<IEnumerable<Servant>> Servants()
        {
            return await _servantService.GetAllServantsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servant>> Servant(int id)
        {
            var servant = await _servantService.GetServantAsync(id);
            if(servant == null)
            {
                return NotFound();
            }
            return servant;
        }
    }
}
