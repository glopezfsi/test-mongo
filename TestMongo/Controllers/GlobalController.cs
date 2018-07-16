using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMongo.Models;
using TestMongo.Services.GlobalService.Abstracts;

namespace TestMongo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GlobalController : Controller
    {
        private readonly IGlobalService _globalService = null;

        public GlobalController(IGlobalService globalService)
        {
            _globalService = globalService;
        }

        // GET: api/Global
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _globalService.GetAllGlobals();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // GET: api/Global/5
        [HttpGet("{key}", Name = "Get")]
        public async Task<IActionResult> Get(string key)
        {
            try
            {
                var result = await _globalService.GetGlobal(key);

                if (result == null)
                    return Json("Global Not Found");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Global
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GlobalModel model)
        {
            try
            {
                await _globalService.AddGlobal(model);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Global/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]GlobalModel model)
        {
            try
            {
                var result = await _globalService.UpdateGlobal(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        { 
            try
            {
                var result = await _globalService.DeleteGlobal(key);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
