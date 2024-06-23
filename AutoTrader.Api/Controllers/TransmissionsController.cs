using AutoTrader.Api.Models;
using AutoTrader.Models.CarInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrader.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : ControllerBase
    {
        private readonly ITransmissionRepository transmissionRepository;
        public TransmissionsController(ITransmissionRepository transmissionRepository)
        {
            this.transmissionRepository = transmissionRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetTransmissionTypes()
        {
            try
            {
                return Ok(await transmissionRepository.GetTransmissionTypes());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving DATA FROM THE Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Transmission>> GetTransmissionType(int id)
        {
            try
            {
                var result = await transmissionRepository.GetTransmissionType(id);
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
        public async Task<ActionResult<Transmission>> CreateTransmissionType(Transmission transmission)
        {
            try
            {
                if (transmission == null)
                {
                    return BadRequest();
                }

                var createdTransmissionType = await transmissionRepository.CreateTransmissionType(transmission);
                return CreatedAtAction(nameof(GetTransmissionType), new { id = createdTransmissionType.TransmissionId }, createdTransmissionType);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving from the database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Transmission>> UpdateTransmissionType(int id, Transmission transmission)
        {
            try
            {
                if (id != transmission.TransmissionId)
                {
                    return BadRequest("nO SUCH Transmission");
                }
                var transmissionTypeToUpdate = transmissionRepository.GetTransmissionType(id);
                if (transmissionTypeToUpdate == null)
                {
                    return NotFound($"Transmission with Id={id} not found");

                }
                return await transmissionRepository.UpdateTransmissionType(transmission);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error ");
            }
        }


    }
}
