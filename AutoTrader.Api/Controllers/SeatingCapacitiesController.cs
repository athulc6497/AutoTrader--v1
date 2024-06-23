using AutoTrader.Api.Models;
using AutoTrader.Models.CarInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrader.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatingCapacitiesController : ControllerBase
    {
        private readonly ISeatingCapacityRepository seatingCapacityRepository;
        public SeatingCapacitiesController(ISeatingCapacityRepository seatingCapacityRepository)
        {
            this.seatingCapacityRepository = seatingCapacityRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetSeatingCapacities()
        {
            try
            {
                return Ok(await seatingCapacityRepository.GetSeatingCapacities());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving DATA FROM THE Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SeatingCapacity>> GetSeatingCapacity(int id)
        {
            try
            {
                var result = await seatingCapacityRepository.GetSeatingCapacity(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<SeatingCapacity>> CreateSeatingCapacity(SeatingCapacity seatingCapacity)
        {
            try
            {
                if (seatingCapacity == null)
                {
                    return BadRequest();
                }

                var createdseatingCapacity = await seatingCapacityRepository.CreateSeatingCapacity(seatingCapacity);
                return CreatedAtAction(nameof(GetSeatingCapacity), new { id = createdseatingCapacity.SeatingCapacityId }, createdseatingCapacity);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving from the database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<SeatingCapacity>> UpdateSeatingCapacity(int id, SeatingCapacity seatingCapacity)
        {
            try
            {
                if (id != seatingCapacity.SeatingCapacityId)
                {
                    return BadRequest("nO SUCH record");
                }
                var seatingCapacityToUpdate = seatingCapacityRepository.GetSeatingCapacity(id);
                if (seatingCapacityToUpdate == null)
                {
                    return NotFound($"Seating Capacity with Id={id} not found");

                }
                return await seatingCapacityRepository.UpdateSeatingCapacity(seatingCapacity);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error ");
            }
        }

    }
}
