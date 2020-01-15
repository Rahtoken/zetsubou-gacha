﻿using Microsoft.AspNetCore.Mvc;
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

        public ServantController(IServantRepository servantRepository)
        {
            this.servantRepository = servantRepository;
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
            Servant servant = await servantRepository.GetServantByIdAsync(id);
            if (servant == null)
            {
                return NotFound();
            }
            return servant;
        }
    }
}
