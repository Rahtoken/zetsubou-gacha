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
        public IEnumerable<Servant> Servants()
        {
            return _servantService.Get();
        }
    }
}
