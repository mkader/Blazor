using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCRUD.API.Models;
using CustomerCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreRepository storeRepository;

        public StoresController(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetStores()
        {
            try
            {
                return Ok(await storeRepository.GetStores());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            try
            {
                var result = await storeRepository.GetStore(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}