using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cargo_WebApi.Models;
using WebApp_Cargo_WebApi.Models.Repositories;

namespace WebApp_Cargo_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoesController : ControllerBase
    {
        private ICargoRepository cargoRepository;
        public CargoesController(ICargoRepository _cargoRepository)
        {
            cargoRepository = _cargoRepository;
        }

        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                return Ok(cargoRepository.GetAll().ToList());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public async Task<ActionResult> FindAll(int id)
        {
            try
            {
                var cargo = await cargoRepository.GetById(id);
                return Ok(cargo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{keyword}")]
        public async Task<ActionResult> Search(string keyword)
        {
            try
            {
                return Ok(cargoRepository.Search(keyword));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{min}/{max}")]
        public async Task<ActionResult> Search(decimal min, decimal max)
        {
            try
            {
                return Ok(cargoRepository.Search(min, max));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("create")]
        public async Task<IActionResult> Create(Cargoes cargo)
        {
            try
            {
                await cargoRepository.Create(cargo);
                return Ok(cargo);
            }
            catch
            {
                return BadRequest();
            }

        }


        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("update")]
        public async Task<ActionResult> Update(Cargoes cargo)
        {
            try
            {
                await cargoRepository.Update(cargo.Id, cargo);
                return Ok(cargo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await cargoRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
